using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class LoginRequestDto
    {
        required public string Email { get; set; }
        required public string Password { get; set; }
    }
}