using Book_Api.Business.Abstract;
using Book_Api.Helpers;
using Book_Api.IRepository;
using Book_Api.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;

        private readonly IBookService _bookManager;

        public BookController(IBookRepository bookRepo, IBookService bookManager)
        {
            _bookRepo = bookRepo;
            _bookManager = bookManager;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Books()
        {
            return Ok(await _bookRepo.GetBooks());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Book(int bookId)
        {
            return Ok(await _bookRepo.GetBook(bookId));
        }
 
        [HttpGet("/GetAllFilter")]
        public IActionResult GetAllFilter(int typeId, List<int?> authors = null, List<int?> publishers = null, decimal? minPrice = 0, decimal? maxPrice = 0) 
        {
            return Json(_bookManager.GetAllByFilter(typeId, authors, publishers, minPrice, maxPrice));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookViewModel model)
        {
            if (model != null)
            {
                return Ok(await _bookRepo.AddBook(model));
            } else {
                return BadRequest();
            }
        }
 

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type(int typeId, int pageCount, int pageSize = 12)
        {
           return  Ok(await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, pageSize));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, pageSize, authorIdList, publisherIdList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, pageSize, authorIdList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, pageSize, publisherIdList));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price(int typeId, int pageCount, int pageSize = 12, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, pageSize, maxPrice, minPrice));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, pageSize, authorIdList, maxPrice, minPrice));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, pageSize, publisherIdList, maxPrice, minPrice));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price(int typeId, int pageCount, int pageSize = 12, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal? maxPrice = 0, decimal? minPrice = 0)
        {
            return Ok(await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, pageSize, authorIdList, publisherIdList, maxPrice, minPrice));
        }

        // ORDER //

        [HttpGet("[action]")]
        public  async Task<IActionResult> GetBooksFilterBy_Type_OrderAZ(int typeId, int pageCount)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, 12);
            
            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_OrderZA(int typeId, int pageCount)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, 12);
            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_OrderUpPrice(int typeId, int pageCount)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, 12);
            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_OrderDownPrice(int typeId, int pageCount)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, 12);
            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_OrderTopSale(int typeId, int pageCount)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type(typeId, pageCount, 12);
            return Ok(FilterHelper.OrderTopSale(books));
        }




        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_OrderAZ(int typeId, int pageCount, List<int?> authorIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel) await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, 12, authorIdList);
            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_OrderZA(int typeId, int pageCount, List<int?> authorIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, 12, authorIdList);
            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_OrderUpPrice(int typeId, int pageCount, List<int?> authorIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, 12, authorIdList);
            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_OrderDownPrice(int typeId, int pageCount, List<int?> authorIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, 12, authorIdList);
            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_OrderTopSale(int typeId, int pageCount, List<int?> authorIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author(typeId, pageCount, 12, authorIdList);
            return Ok(FilterHelper.OrderTopSale(books));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_OrderAZ(int typeId, int pageCount, List<int?> publisherIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel) await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, 12, publisherIdList);
            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_OrderZA(int typeId, int pageCount, List<int?> publisherIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, 12, publisherIdList);
            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_OrderUpPrice(int typeId, int pageCount, List<int?> publisherIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, 12, publisherIdList);
           
            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_OrderDownPrice(int typeId, int pageCount, List<int?> publisherIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, 12, publisherIdList);
           
            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_OrderTopSale(int typeId, int pageCount, List<int?> publisherIdList)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher(typeId, pageCount, 12, publisherIdList);
           
            return Ok(FilterHelper.OrderTopSale(books));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price_OrderAZ(int typeId, int pageCount, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, 12, maxPrice, minPrice);
           
            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price_OrderZA(int typeId, int pageCount, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, 12, maxPrice, minPrice);

            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price_OrderUpPrice(int typeId, int pageCount, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, 12, maxPrice, minPrice);

            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price_OrderDownPrice(int typeId, int pageCount, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, 12, maxPrice, minPrice);

            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Price_OrderTopSale(int typeId, int pageCount, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Price(typeId, pageCount, 12, maxPrice, minPrice);

            return Ok(FilterHelper.OrderTopSale(books));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_OrderAZ(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, 12, authorIdList, publisherIdList);

            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_OrderZA(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, 12, authorIdList, publisherIdList);

            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_OrderUpPrice(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, 12, authorIdList, publisherIdList);

            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_OrderDownPrice(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, 12, authorIdList, publisherIdList);

            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_OrderTopSale(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher(typeId, pageCount, 12, authorIdList, publisherIdList);

            return Ok(FilterHelper.OrderTopSale(books));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price_OrderAZ(int typeId, int pageCount, List<int?> authorIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, 12, authorIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price_OrderZA(int typeId, int pageCount, List<int?> authorIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, 12, authorIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price_OrderUpPrice(int typeId, int pageCount, List<int?> authorIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, 12, authorIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price_OrderDownPrice(int typeId, int pageCount, List<int?> authorIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, 12, authorIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Price_OrderTopSale(int typeId, int pageCount, List<int?> authorIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Price(typeId, pageCount, 12, authorIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderTopSale(books));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price_OrderAZ(int typeId, int pageCount, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, 12, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderAZ(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price_OrderZA(int typeId, int pageCount, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, 12, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price_OrderUpPrice(int typeId, int pageCount, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, 12, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price_OrderDownPrice(int typeId, int pageCount, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, 12, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Publisher_Price_OrderTopSale(int typeId, int pageCount, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Publisher_Price(typeId, pageCount, 12, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderTopSale(books));
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price_OrderAZ(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, 12, authorIdList, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderAZ(books)); 
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price_OrderZA(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, 12, authorIdList, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderZA(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price_OrderUpPrice(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, 12, authorIdList, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderUpPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price_OrderDownPrice(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, 12, authorIdList, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderDownPrice(books));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksFilterBy_Type_Author_Publisher_Price_OrderTopSale(int typeId, int pageCount, List<int?> authorIdList = null, List<int?> publisherIdList = null, decimal maxPrice = 0, decimal minPrice = 0)
        {
            BooksAndCountViewModel books = (BooksAndCountViewModel)await _bookRepo.GetBooksFilterBy_Type_Author_Publisher_Price(typeId, pageCount, 12, authorIdList, publisherIdList, maxPrice, minPrice);

            return Ok(FilterHelper.OrderTopSale(books));
        }


        // ORDER //
    }
}