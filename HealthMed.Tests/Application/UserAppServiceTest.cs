using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Application.Services;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Enums;
using HealthMed.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Tests.Application
{
    public class UserAppServiceTest
    {
        private Mock<IConfiguration> _configurationMock;
        private Mock<IUserRepository> _repositoryMock;
        private IUserAppService _userAppService;
        public UserAppServiceTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryMock = new Mock<IUserRepository>();
            _userAppService = new UserAppService(_configurationMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task ShouldCreateANewPatientUser()
        {
            var newUserDto = new CreateUserDTO
            {
                Name = "Test",
                CPF = "35944781068",
                Email = "teste@teste.com",
                Password = "123456",
                PersonType = EPersonType.Patient.GetHashCode(),
            };

            var createdUser = await _userAppService.Create(newUserDto);

            Assert.True(createdUser.Success);
            Assert.NotNull(createdUser.Data);
        }
        [Fact]
        public async Task ShouldCreateANewDoctorUser()
        {
            var newUserDto = new CreateUserDTO
            {
                Name = "Test",
                CPF = "35944781068",
                Email = "teste@teste.com",
                Password = "123456",
                CRM = "0000-SP",
                PersonType = EPersonType.Doctor.GetHashCode(),
            };

            var createdUser = await _userAppService.Create(newUserDto);

            Assert.True(createdUser.Success);
            Assert.NotNull(createdUser.Data);
        }
        [Fact]
        public async Task ShouldNotCreateAnDuplicatedUser()
        {
            var newUserDto = new CreateUserDTO
            {
                Name = "Test2",
                CPF = "35944781068",
                Email = "teste@teste.com",
                Password = "123456",
                PersonType = EPersonType.Patient.GetHashCode(),
            };

            _repositoryMock.Setup(x => x.CheckIfUserNameAlreadyExists(newUserDto.Email))
                .Returns(async () => GetUsers().Any(x => x.UserName == newUserDto.Email));
            _userAppService = new UserAppService(_configurationMock.Object, _repositoryMock.Object);

            var createdUser = await _userAppService.Create(newUserDto);

            Assert.False(createdUser.Success);
            Assert.Contains("User already exists.", createdUser.ErrorMessages);
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>{
                new User
                {
                    UserName = "teste@teste.com",
                }
            };

            return users;
        }
    }
}
