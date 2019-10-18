using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsByClientId(int ClientId)
        {
            return await _context.Products
            .Where(x => x.ClientId == ClientId)
            .ToListAsync();
        }

        public async Task<Products> GetProductDetailById(int Id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Movements[]> GetProductMovementsById(int Id)
        {
            return await _context.Movements
            .Where(x => x.Id == Id)
            .ToArrayAsync();
        }

        public async Task<Movements[]> GetByProductId(int ProductId)
        {
            return await _context.Movements.Where(x => x.Products.Id == ProductId).ToArrayAsync();
        }

        public void UpdateProductBalanceById(int Id, decimal amount)
        {

            var query = (from prod in _context.Products
            select prod)
            .Where(m => m.Id == Id)
            .ToList();

            foreach(Products prod in query)
            {
                prod.current_balance = prod.current_balance + amount;
            }

            _context.SaveChanges();
        }

        public async Task Update(Products products)
        {
            var query = (from prod in _context.Products
                         select prod)
            .Where(m => m.Id == products.Id)
            .ToList();

            foreach (Products prod in query)
            {
                prod.current_balance = products.current_balance;
            }

           await _context.SaveChangesAsync();

        }

    }
}

