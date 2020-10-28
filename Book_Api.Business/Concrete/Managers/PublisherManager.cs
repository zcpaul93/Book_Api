using System.Collections.Generic;
using Book_Api.Business.Abstract;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;

namespace Book_Api.Business.Concrete.Managers
{
    public class PublisherManager : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherManager(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public Publisher Add(Publisher publisher)
        {
            return _publisherRepository.Add(publisher);
        }

        public Publisher Get(int Id)
        {
            return _publisherRepository.Get(x => x.Id == Id);
        }

        public List<Publisher> GetAll()
        {
            return _publisherRepository.GetAll();
        }

        public List<Publisher> GetAllByTypeAndAuthor(int skip, int bookTypeId, List<int?> authorIdList = null)
        {
            return _publisherRepository.GetAllByTypeAndAuthor(skip, bookTypeId, authorIdList);
        }

        public List<Publisher> GetPublishersByNameTextSearch(string search)
        {
            return _publisherRepository.GetPublishersByNameTextSearch(search);
        }

        public Publisher Update(Publisher publisher)
        {
            return _publisherRepository.Update(publisher);
        }
    }
}
