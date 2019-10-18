using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IProductTypeService
    {
        Task<ProductType[]> GetAll();
    }
}
