using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;
        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductType[]> GetAll()
        {
            return await _context.ProductTypes.ToArrayAsync();
        }
    }
}
