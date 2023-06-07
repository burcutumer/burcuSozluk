using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
    public class CreateUserDto
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class UpdateUserDto
    {
        public string? CurrentPassword { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}