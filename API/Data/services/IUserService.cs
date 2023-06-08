using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;

namespace API.Data.services
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto user);
        Task<Response<UserDto>> DeleteUserAsync(int userId);
        Task<Response<UserDto>> GetCurrentAsync(string userEmail);
        Task<Response<bool>> UpdateUserAsync(UpdateUserDto dto, int userId);
    }
}