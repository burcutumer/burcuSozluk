using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;

namespace API.Data.Services
{
    public interface IAuthService
    {
        Task<Response<LoginResponseDto>> CheckUserCredentials(LoginRequestDto requestDto);
    }
}