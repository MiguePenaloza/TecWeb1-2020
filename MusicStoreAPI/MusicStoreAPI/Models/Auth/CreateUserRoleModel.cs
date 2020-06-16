using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models.Auth
{
    public class CreateUserRoleModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
