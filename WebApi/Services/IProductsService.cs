using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetProductsByClientId(int ClientId);
        Task<Products> GetProductDetailById(int Id);
        Task<Movements[]> GetProductMovementsById(int Id);
        Task<Movements[]> GetByProductId(int ProductId);
        Task<IEnumerable<Products>> GetAsync();
        void UpdateProductBalanceById(int id, decimal amount);
        Task Update(Products productUpdate);
    }
}