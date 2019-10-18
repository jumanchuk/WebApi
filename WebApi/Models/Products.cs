using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId {get; set;}
        [Required]
        public decimal current_balance { get; set; }
        [Required]
        public int status { get; set; }
        public DateTime Opening_date { get; set; }
        public DateTime? Closing_date { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ProductType ProductType  { get; set; }
    }

}