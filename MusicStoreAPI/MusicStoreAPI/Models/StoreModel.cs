using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Invalid name length")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public virtual IEnumerable<InstrumentModel> Instruments { get; set; }
    }
}
