using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Api.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : Controller
    {
        readonly ITypeRepository _typeRepo;
        public TypeController(ITypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Types()
        {
            return Ok(await _typeRepo.GetTypes());
        }
    }
}