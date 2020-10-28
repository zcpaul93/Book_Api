using Book_Api.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorManager;
        public AuthorController(IAuthorService authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByTypeAndPublisher(int skip, int bookTypeId, List<int?> publisherIdList = null)
        {
            return Ok(_authorManager.GetAllByTypeAndPublisher(skip, bookTypeId, publisherIdList));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_authorManager.GetAll());
        }

        [HttpGet("[action]")]
        public IActionResult GetAuthorsByNameTextSearch(string search)
        {
            return Ok(_authorManager.GetAuthorsByNameTextSearch(search));
        }
    }
}