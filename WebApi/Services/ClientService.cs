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
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetById(int Id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<IEnumerable<Cliente>> GetAsync()
        {
                return await _context.Clientes
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task AddAsync(Cliente cliente)
        {
            cliente.Date = DateTime.Now;
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> GetClient(int Document)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Document == Document);
        }
    }
}