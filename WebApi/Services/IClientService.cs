using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IClientService
    {
        Task<Cliente> GetClient(int Document);
        Task<Cliente> GetById(int Id);
        Task<IEnumerable<Cliente>> GetAsync();
        Task AddAsync(Cliente cliente);
    }
}