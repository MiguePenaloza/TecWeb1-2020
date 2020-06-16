using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Models
{
    public class ProductModel
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage = "To many characters")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
