using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class MovementsType
    {
        public int Id { get; set; }
        public int Movements_type { get; set; }
        public string name { get; set; }
        public int status { get; set; }

    }

}