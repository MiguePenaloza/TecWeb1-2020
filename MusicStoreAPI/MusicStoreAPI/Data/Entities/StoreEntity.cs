using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data.Entities
{
    public class StoreEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<InstrumentEntity> Instruments { get; set; }
    }
}
