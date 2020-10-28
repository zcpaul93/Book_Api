using Book_Api.Business.Abstract;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Book_Api.Business.Concrete.Managers
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author Add(Author author)
        {
            return _authorRepository.Add(author);
        }

        public Author Get(int Id)
        {
            return _authorRepository.Get(a => a.Id == Id);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public List<Author> GetAllByTypeAndPublisher(int skip, int bookTypeId, List<int?> publisherIdList = null)
        {
            return _authorRepository.GetAllByTypeAndPublisher(skip, bookTypeId, publisherIdList);
        }

        public List<Author> GetAuthorsByNameTextSearch(string search)
        {
            return _authorRepository.GetAuthorsByNameTextSearch(search);
        }

        public Author Update(Author author)
        {
            return _authorRepository.Update(author);
        }
    }
}
