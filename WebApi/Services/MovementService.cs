using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class MovementService : IMovementService
    {
        private readonly ApplicationDbContext _context;
        public MovementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Movements movement)
        {
            movement.date = DateTime.Now;            

            _context.Movements.Add(movement);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<IEnumerable<Movements>> SearchAsync(int Id, int pageNumber, int pageSize)
        {
            return await _context.Movements
            .Where(x => x.Id == Id)
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToArrayAsync();
        }

    }
}
