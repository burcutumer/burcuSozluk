using API.Data.DTOs;
using API.Data.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController :BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "member,admin")]
        [HttpGet]
        public async Task<ActionResult<Response<UserDto>>> GetCurrentUser()
        {
            var userEmail = User.Identity?.Name;
            var result = await _userService.GetCurrentAsync(userEmail!);
             if (result.Error!= null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Response<UserDto>>> CreateUser([FromBody] CreateUserDto userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
             if (result.Error!= null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "member")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<UserDto>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "member")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<bool>>> UpdateUser([FromBody] UpdateUserDto user, int id)
        {
            var result = await _userService.UpdateUserAsync(user, id);

            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}