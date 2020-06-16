using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstrumentAPI.Models
{
    public class InstrumentModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100000)]
        [Required]
        public decimal? Price { get; set; }
        [MaxLength(50, ErrorMessage ="To much letters")]
        public string Description { get; set; }
        public bool? Discount { get; set; }
    }
}
