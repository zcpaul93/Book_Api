using Book_Api.Business.Abstract;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Business.Concrete.Managers
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentManager(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment Add(Comment comment)
        {
           return  _commentRepository.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentRepository.Delete(comment);
        }

        public List<Comment> GetAll(int bookId)
        {
            return _commentRepository.GetAll(c => c.Book.BookId == bookId);
        }

        public Comment Update(Comment comment)
        {
            return _commentRepository.Update(comment);
        }
    }
}
