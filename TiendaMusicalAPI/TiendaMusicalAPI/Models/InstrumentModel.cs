using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstrumentAPI.Models
{
    public class InstrumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public bool? Discount { get; set; }
    }
}
