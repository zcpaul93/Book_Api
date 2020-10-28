using Book_Api.Business.Abstract;
using Book_Api.Core.HelperModels;
using Book_Api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookManager;

        public BookController(IBookService bookManager)
        {
            _bookManager = bookManager;
        }
     
        [HttpGet("[action]")]
        public IActionResult Books()
        {
            return Ok(_bookManager.GetAll());
        }
        [HttpGet("[action]")]
        public IActionResult GetNewBooks()
        {
            return Ok(_bookManager.GetNewBooks());
        }

        [HttpGet("[action]")]
        public IActionResult GetTopSaleBooks()
        {
            return Ok(_bookManager.GetTopSaleBooks());
        }

        [HttpGet("[action]")]
        public IActionResult GetMyChooseBooks()
        {
            return Ok(_bookManager.GetMyChooseBooks());
        }

        [HttpGet("[action]")]
        public IActionResult Book(int bookId)
        {
            return Ok(_bookManager.GetBookByIdWithAuthorPublisher(bookId));
        }

        [HttpGet("[action]")]
        public IActionResult GetBooksByNameTextSearch(string search)
        {
            return Ok(_bookManager.GetBooksByNameTextSearch(search));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddBook([FromBody] Book model)
        {
            if (model != null)
            {
                return Ok(_bookManager.Add(model));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("[action]")]
        public IActionResult GetAllFilterType(int typeId, int pageCount, int pageSize = 12, 
            List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? minPrice = 0, 
            decimal? maxPrice = 0) 
        {
            var bookFilterModel = new BookFilterModel { 
                TypeId = typeId,
                PageCount = pageCount,
                PageSize = pageSize,
                Authors = authorIdList,
                Publishers = publisherIdList,
                MaxPrice = maxPrice,
                MinPrice = minPrice
            };

            return Ok(_bookManager.GetAllByFilterType(bookFilterModel));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByFilterAZ(int typeId, int pageCount, int pageSize = 12,
            List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? minPrice = 0,
            decimal? maxPrice = 0)
        {
            var bookFilterModel = new BookFilterModel
            {
                TypeId = typeId,
                PageCount = pageCount,
                PageSize = pageSize,
                Authors = authorIdList,
                Publishers = publisherIdList,
                MaxPrice = maxPrice,
                MinPrice = minPrice
            };

            return Ok(_bookManager.GetAllByFilterAZ(bookFilterModel));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByFilterZA(int typeId, int pageCount, int pageSize = 12,
            List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? minPrice = 0,
            decimal? maxPrice = 0)
        {
            var bookFilterModel = new BookFilterModel
            {
                TypeId = typeId,
                PageCount = pageCount,
                PageSize = pageSize,
                Authors = authorIdList,
                Publishers = publisherIdList,
                MaxPrice = maxPrice,
                MinPrice = minPrice
            };

            return Ok(_bookManager.GetAllByFilterZA(bookFilterModel));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllByFilterPriceUpToDown(int typeId, int pageCount, int pageSize = 12,
            List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? minPrice = 0,
            decimal? maxPrice = 0)
        {
            var bookFilterModel = new BookFilterModel
            {
                TypeId = typeId,
                PageCount = pageCount,
                PageSize = pageSize,
                Authors = authorIdList,
                Publishers = publisherIdList,
                MaxPrice = maxPrice,
                MinPrice = minPrice
            };

            return Ok(_bookManager.GetAllByFilterPriceUpToDown(bookFilterModel));
        }


        [HttpGet("[action]")]
        public IActionResult GetAllByFilterPriceDownToUp(int typeId, int pageCount, int pageSize = 12,
            List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? minPrice = 0,
            decimal? maxPrice = 0)
        {
            var bookFilterModel = new BookFilterModel
            {
                TypeId = typeId,
                PageCount = pageCount,
                PageSize = pageSize,
                Authors = authorIdList,
                Publishers = publisherIdList,
                MaxPrice = maxPrice,
                MinPrice = minPrice
            };

            return Ok(_bookManager.GetAllByFilterPriceDownToUp(bookFilterModel));
        }

    }
}