using Book_Api.Business.Abstract;
using Book_Api.Core;
using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<AppSettings> appSettings,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] Register formData)
        {
            var errorList = new List<string>();

            var user = new User
            {
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Email = formData.Email,
                UserName = formData.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, formData.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");

                //Sending Confirmation Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = user.Id, Code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(user.Email,
                 "www.kitapp.com - Mail Onayı",
                 "Lütfen email onayı için linke tıklayın:<a href=\"" + callbackUrl + "\">buraya tıklayınız</a>");

                return Ok(new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    userName = user.UserName,
                    email = user.Email,
                    status = 1,
                    message = "Registration Succesful!"
                });

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorList.Add(error.Description);
                }
            }

            return BadRequest(new JsonResult(errorList));
        }
        
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Autheticate([FromBody] Login formData)
        {
            var user = await _userManager.FindByNameAsync(formData.Username);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            double tokenExpiryTime = Convert.ToDouble(_appSettings.ExpireTime);
             
            if (user != null && await _userManager.CheckPasswordAsync(user, formData.Password))
            {
                //Confirmation of email check
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "User has not confirmed email.");

                    return Unauthorized();
                }

                var roles = await _userManager.GetRolesAsync(user);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, formData.Username),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                            new Claim("LoggedOn", DateTime.Now.ToString())
                        }),

                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _appSettings.Site,
                    Audience = _appSettings.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };

                //Generate Token
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    expiration = token.ValidTo,
                    username = user.UserName,
                    userRole = roles.FirstOrDefault(),
                    id = user.Id,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    email = user.Email
                });
            }

            ModelState.AddModelError("", "Username/Password was not found!");
            return Unauthorized();
        }

        [Authorize]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetUser() 
        {
           var username = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
           var user = await _userManager.FindByNameAsync(username);
           var roles = await _userManager.GetRolesAsync(user);

            return Ok(new { 
                id= user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                username = user.UserName,
                email = user.Email,
                userRole = roles.FirstOrDefault()
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }
          
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new JsonResult("ERROR");
            }
            if (user.EmailConfirmed)
            {
                return Redirect("/login");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return RedirectToAction("EmailConfirmed", "Notification", new { userId, code });
            }
            else
            {
                var errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ToString());
                }

                return new JsonResult(errors);
            }

        }
    }
}