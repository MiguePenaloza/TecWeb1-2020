using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models
{
    public class InstrumentModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Invalid name length")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 1000000)]
        public int? Price { get; set; }
        public int StoreId { get; set; }
    }
}
