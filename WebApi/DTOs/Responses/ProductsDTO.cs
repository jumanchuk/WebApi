using System;
using WebApi.Models;

namespace WebApi.DTOs.Responses
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public decimal current_balance { get; set; }
        public int status { get; set; }
        public DateTime Opening_date { get; set; }
        public DateTime? Closing_date { get; set; }
        public virtual ProductType ProductType { get; set; }

    }
}
