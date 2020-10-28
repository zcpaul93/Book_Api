using Book_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Business.Abstract
{
    public interface ITypeService
    {
        List<Types> GetAll();
    }
}
