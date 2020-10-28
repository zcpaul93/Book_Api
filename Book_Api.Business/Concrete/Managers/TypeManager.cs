using Book_Api.Business.Abstract;
using Book_Api.Data.Models;
using Book_Api.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Api.Business.Concrete.Managers
{
    public class TypeManager : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        public TypeManager(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public List<Types> GetAll() => _typeRepository.GetAll();
    }
}
