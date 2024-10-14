using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using HealthMed.Shared;
using HealthMed.Shared.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public AuthenticationAppService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        public async Task<Result<TokenDTO>> Login(string username, string password)
        {
            var passwordHash = PasswordHasher.HashSHA256(password);

            var user = await _userRepository.GetUserByLogin(username, passwordHash);

            if (user == null)
                return new Result<TokenDTO>().AddErrorMessage("Invalid username or password.");

            return new Result<TokenDTO>(
                new TokenDTO
                {
                    PersonName = user.Person.Name,
                    Token = GenerateToken(user),
                });
        }
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt:Key").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.Person.Name),
                    new Claim(ClaimTypes.Role, user.Profile.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                   SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
