using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreAPI.Models.Auth;
using MusicStoreAPI.Services;


namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        // /api/auth/userx  
        [HttpPost("User")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        [HttpPost("Role")]
        public async Task<IActionResult> CreateRolenAsync([FromBody]CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.CreateRoleAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("UserRole")]
        public async Task<IActionResult> CreateUserRolenAsync([FromBody]CreateUserRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserRoleAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

    }
}


/*


namespace MusicStoreAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        // /api/auth/user
        [HttpPost("User")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result);  //Status Code: 200
                
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); //Status Code: 400
        }

        [HttpPost("Role")]
        public async Task<IActionResult> CreateRoleAsync([FromBody]CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.CreateRoleAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }

        [HttpPost("UserRole")]
        public async Task<IActionResult> CreateUserRoleAsync([FromBody]CreateUserRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserRoleAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest("Some properties aren't valid");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties aren't valid");
        }
    }
}*/