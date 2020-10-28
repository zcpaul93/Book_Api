using Book_Api.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepo;
        public PublisherController(IPublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Publishers(int skip, int bookTypeId, List<int?> authorIdList = null)
        {
            return Ok(await _publisherRepo.GetPublishers(skip, bookTypeId, authorIdList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AllPublishers()
        {
            return Ok(await _publisherRepo.GetAllPublishers());
        }
    }
}
