using Book_Api.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : Controller
    {
        readonly ITypeService _typeManager;
        public TypeController(ITypeService typeManager)
        {
            _typeManager = typeManager;
        }

        [HttpGet("[action]")]
        public IActionResult Types()
        {
            return Ok(_typeManager.GetAll());
        }
    }
}