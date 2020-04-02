using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Data.Entities
{
    public class VoteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int? Year { get; set; }
        public int SongId { get; set; }
    }
}
