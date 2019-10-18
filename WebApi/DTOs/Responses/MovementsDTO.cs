using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DTOs.Responses
{
    public class MovementsDTO
    {

        public int Id { get; set; }
        public int ProductsId { get; set; }
        public decimal amount { get; set; }
        public int status { get; set; }
        public DateTime date { get; set; }
        public virtual Products Products { get; set; }
        public virtual MovementsType MovementsType { get; set; }

    }
}
