using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class LoginResponseDto
    {
        required public string JwtToken { get; set; }
    }
}