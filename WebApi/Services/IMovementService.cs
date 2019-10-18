using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IMovementService
    {
        Task<bool> AddAsync(Movements movement);
        Task<IEnumerable<Movements>> SearchAsync(int Id, int value1, int value2);
    }
}
