using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data.Entities
{
    public class InstrumentEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        [ForeignKey("StoreId")]
        public virtual StoreEntity Store { get; set; }
    }
}
