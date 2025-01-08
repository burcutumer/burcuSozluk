using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        required public string NickName { get; set; }
        required public string Email { get; set; }
    }
    public class CreateUserDto
    {
        required public string NickName { get; set; }
        required public string Email { get; set; }
        required public string Password { get; set; }
    }
    public class UpdateUserDto
    {
        required public string CurrentPassword { get; set; }
        required public string Password { get; set; }
    }
}