using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using HealthMed.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public UserAppService(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        public async Task<Result<User>> Create(CreateUserDTO dto)
        {
            var userNameAlreadyExists = await _userRepository.CheckIfUserNameAlreadyExists(dto.Email);

            if (userNameAlreadyExists) return new Result<User>().AddErrorMessage("User already exists.");

            var person = Person.Create(
                dto.Name,
                dto.CPF,
                dto.Email,
                (Domain.Enums.EPersonType)dto.PersonType,
                dto.CRM);

            var user = User.Create(dto.Password, person);

            await _userRepository.Insert(user);

            return new Result<User>(
                user);
        }
    }
}
