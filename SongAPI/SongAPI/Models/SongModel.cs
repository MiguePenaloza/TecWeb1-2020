using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Models
{
    public class SongModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage = "Invalid Name Lenght")]
        public string Artist { get; set; }
        public double? Length { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public IEnumerable<VoteModel> Votes { get; set; }
    }
}
