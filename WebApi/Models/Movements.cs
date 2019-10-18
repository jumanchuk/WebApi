using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Movements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductsId { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int status { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public virtual Products Products  { get; set; }
        public virtual MovementsType MovementsType  { get; set; }
    }

}