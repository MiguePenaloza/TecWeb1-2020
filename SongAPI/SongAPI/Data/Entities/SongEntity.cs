using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Data.Entities
{
    public class SongEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public double? Length { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public List<VoteEntity> Votes { get; set; }
        //public IEnumerable<VoteEntity> Votes { get; set; }
    }
}