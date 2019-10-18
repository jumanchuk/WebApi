using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.WebApi.DTOs.Requests
{
    public class ClienteAddDTO
    {

        [Required]
        public int Document { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(60)]
        [Required]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
