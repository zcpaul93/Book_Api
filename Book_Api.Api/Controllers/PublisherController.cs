using Book_Api.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllTypeAndAuthor(int skip, int bookTypeId, List<int?> authorIdList = null)
        {
            return Ok(_publisherService.GetAllByTypeAndAuthor(skip, bookTypeId, authorIdList));
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_publisherService.GetAll());
        }

        [HttpGet("[action]")]
        public IActionResult GetPublishersByNameTextSearch(string search)
        {
            return Ok(_publisherService.GetPublishersByNameTextSearch(search));
        }
    }
}
