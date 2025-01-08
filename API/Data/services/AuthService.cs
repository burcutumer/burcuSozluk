using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _secretKey = config["Jwt:Secret"];
        }

        public async Task<Response<LoginResponseDto>> CheckUserCredentials(LoginRequestDto requestDto)
        {
            var user = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user == null)
            {
                return new Response<LoginResponseDto>
                {
                    Error = "User is not found"
                };
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, requestDto.Password, false);

            if (!result.Succeeded)
            {
                return new Response<LoginResponseDto>
                {
                    Error = "User is not found"
                };
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, requestDto.Email)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role,r)));

            var token = GenerateJwtToken(_secretKey, 10, claims);
            return new Response<LoginResponseDto>
            {
                Data = new LoginResponseDto
                {
                    JwtToken = token
                }
            };
        }
        private static string GenerateJwtToken(string secretKey, int expireMinutes, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}