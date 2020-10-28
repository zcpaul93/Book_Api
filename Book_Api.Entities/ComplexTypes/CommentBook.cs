using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Entities.ComplexTypes
{
    public class CommentBook
    {
        public Comment Comment { get; set; }
        public Book Book { get; set; }
    }
}
