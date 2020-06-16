using MusicStoreAPI.Models;
using MusicStoreAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);

        Task<UserManagerResponse> CreateRoleAsync(CreateRoleModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginModel model);

        Task<UserManagerResponse> CreateUserRoleAsync(CreateUserRoleModel model); 
    }
}
