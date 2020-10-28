using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Api.Business.Abstract;
using Book_Api.Data.Models;
using Book_Api.Entities.ComplexTypes;
using Microsoft.AspNetCore.Mvc;

namespace Book_Api.Api.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentManager;
        private readonly IBookService _bookManager;
        public CommentController(ICommentService commentManager, IBookService bookManager)
        {
            _commentManager = commentManager;
            _bookManager = bookManager;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(int bookId) 
        {
            return Ok(_commentManager.GetAll(bookId));
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromBody] CommentBook model)
        {
            try
            {
                var comment = _commentManager.Add(model.Comment);

                var book = model.Book;
                var rating = model.Book.Rating * model.Book.RatingTotalCount;

                book.RatingTotalCount += 1;
                book.Rating = (model.Comment.Rating + rating) / book.RatingTotalCount;
                _bookManager.Update(book);
              
                return Ok(comment);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

    }
}