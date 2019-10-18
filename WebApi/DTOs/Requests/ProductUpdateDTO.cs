﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace Banco.WebApi.DTOs.Requests
{
    public class ProductUpdateDTO
    {
 
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal current_balance { get; set; }

    }
}
