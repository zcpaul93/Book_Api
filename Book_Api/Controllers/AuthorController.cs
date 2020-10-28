using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Api.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Authors(int skip , int bookTypeId, List<int?> publisherIdList = null)
        {
            return Ok(await _authorRepo.GetAuthors(skip,bookTypeId,publisherIdList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AllAuthors()
        {
            return Ok(await _authorRepo.GetAllAuthors());
        }
    }
}