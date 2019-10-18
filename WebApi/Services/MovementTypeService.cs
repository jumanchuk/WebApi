using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services
{
    public class MovementTypeService : IMovementTypeService
    {
        private readonly ApplicationDbContext _context;
        public MovementTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MovementsType[]> GetAll()
        {
            return await _context.MovementsType.ToArrayAsync();
        }

        public async Task<MovementsType> GetByType(int movementType)
        {
            return await _context.MovementsType.FirstOrDefaultAsync(x => x.Movements_type == movementType);
        }
    }
}
