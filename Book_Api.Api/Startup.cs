using Book_Api.Business.Abstract;
using Book_Api.Business.Concrete;
using Book_Api.Business.Concrete.Managers;
using Book_Api.Core;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using Book_Api.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace Book_Api.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddCors(options => options.AddPolicy("EnableCORS", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

            services.AddDbContext<BookDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
 

            services.AddScoped<IBookRepository, EfBookRepository>();
            services.AddScoped<ITypeRepository, EfTypeRepository>();
            services.AddScoped<IAuthorRepository, EfAuthorRepository>();
            services.AddScoped<IPublisherRepository, EfPublisherRepository>();
            services.AddScoped<ICommentRepository, EfCommentRepository>();
           
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<ITypeService, TypeManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IPublisherService, PublisherManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<ICommentService, CommentManager>();

            services.AddTransient<IEmailSender, SendGridEmailSender>();


            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                //Lockout Setting
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<BookDbContext>().AddDefaultTokenProviders();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Site,
                    ValidAudience = appSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddAuthorization(options => {
                options.AddPolicy("RequireLoggedIn", policy =>
                    policy.RequireRole("Admin", "Customer").RequireAuthenticatedUser());

                options.AddPolicy("RequireAdministratorRole", policy =>
                    policy.RequireRole("Admin").RequireAuthenticatedUser());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
