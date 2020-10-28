using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll(int bookId);

        Comment Add(Comment comment);
        Comment Update(Comment comment);
        void Delete(Comment comment);
    }
}
