using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public int Document { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(60)]
        [Required]
        public string Lastname { get; set; }

        public DateTime Date { get; set; }

    }
}
