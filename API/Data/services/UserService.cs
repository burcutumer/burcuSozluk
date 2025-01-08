using API.Data.DTOs;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;

        }
        public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto userDto)
        {
            if (userDto != null)
            {
                var user = new User
                {
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    NickName = userDto.NickName
                };

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (!result.Succeeded)
                {
                    return new Response<UserDto>
                    {
                        Error = result.Errors.Select(e => e.Description).ToList()
                    };
                }
                await _userManager.AddToRoleAsync(user, "member");

                return MaptoResponseUserDto(user);
            }
            return new Response<UserDto>
            {
                Error = "User can not created"
            };
        }

        public async Task<Response<UserDto>> DeleteUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new Response<UserDto>()
                {
                    Error = "User not found"
                };
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return new Response<UserDto>()
                {
                    Error = "User can not delete"
                };
            }

            return MaptoResponseUserDto(user);
        }

        public async Task<Response<UserDto>> GetCurrentAsync(string userEmail)
        {
            var user = await _userManager.Users
                .Include(e => e.Entries)
                .FirstOrDefaultAsync(i => i.Email == userEmail);

            if (user == null)
            {
                return new Response<UserDto>()
                {
                    Error = "User not found"
                };
            }
            return MaptoResponseUserDto(user);
        }

        public async Task<Response<bool>> UpdateUserAsync(UpdateUserDto dto, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                if (dto.CurrentPassword != null && dto.Password != null)
                {
                    var res = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.Password);

                    if (!res.Succeeded)
                    {
                        return new Response<bool>()
                        {
                            Error = res.Errors.Select(e => e.Description).ToArray()
                        };
                    }
                    return new Response<bool>
                    {
                        Data = true
                    };
                }
            }
            return new Response<bool>()
            {
                Error = "User not found"
            };
        }

        private static Response<UserDto> MaptoResponseUserDto(User user)
        {
            return new Response<UserDto>
            {
                Data = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    NickName = user.NickName
                }
            };
        }
    }
}