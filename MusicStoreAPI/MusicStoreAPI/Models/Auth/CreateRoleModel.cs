using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models.Auth
{
    public class CreateRoleModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }
    }
}
