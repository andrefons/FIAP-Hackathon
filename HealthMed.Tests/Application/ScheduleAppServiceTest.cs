using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Application.Services;
using HealthMed.Domain.Entities;
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
    public class ScheduleAppServiceTest
    {
        private Mock<IConfiguration> _configurationMock;
        private Mock<IScheduleRepository> _repositoryMock;
        private IScheduleAppService _service;
        public ScheduleAppServiceTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryMock = new Mock<IScheduleRepository>();
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);
        }
        [Fact]
        public async void ShouldReturnAllSchedulesByDoctor()
        {
            var doctorId = 1;

            _repositoryMock = new Mock<IScheduleRepository>();
            _repositoryMock.Setup(x => x.GetAllByDoctorId(doctorId))
                .Returns(async () => GetSchedules().Where(y => y.DoctorId == doctorId));
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);

            var schedules = await _service.GetAllByDoctorId(doctorId);

            Assert.True(schedules.Success);
            Assert.NotNull(schedules.Data);
            Assert.Equal(5, schedules.Data.Count());
        }
        [Fact]
        public async void ShouldNotReturnAnySchedulesByDoctor()
        {
            var doctorId = 6;

            _repositoryMock = new Mock<IScheduleRepository>();
            _repositoryMock.Setup(x => x.GetAllByDoctorId(doctorId))
                .Returns(async () => GetSchedules().Where(y => y.DoctorId == doctorId));
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);

            var schedules = await _service.GetAllAvailablesByDoctorId(doctorId);

            Assert.True(schedules.Success);
            Assert.NotNull(schedules.Data);
            Assert.Equal(0, schedules.Data.Count());
        }
        [Fact]
        public async void ShouldReturnAllAvailableSchedulesByDoctor()
        {
            var doctorId = 1;

            _repositoryMock = new Mock<IScheduleRepository>();
            _repositoryMock.Setup(x => x.GetAllAvailablesByDoctorId(doctorId))
                .Returns(async () => GetSchedules().Where(y => y.DoctorId == doctorId));
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);

            var schedules = await _service.GetAllAvailablesByDoctorId(doctorId);

            Assert.True(schedules.Success);
            Assert.NotNull(schedules.Data);
            Assert.Equal(5, schedules.Data.Count());
        }
        [Fact]
        public async void ShouldCreateANewSchedule()
        {
            var scheduleDto = new CreateScheduleDTO
            {
                DoctorId = 1,
                Date = new DateTime(2024, 10, 13, 15, 0, 0)
            };

            var schedule = new Schedule
            {
                DoctorId = scheduleDto.DoctorId,
                Date = scheduleDto.Date
            };

            _repositoryMock = new Mock<IScheduleRepository>();
            _repositoryMock.Setup(x => x.CheckIfAlreadyExists(schedule.DoctorId, schedule.Date))
                .Returns(async () => GetSchedules().Any(y => y.DoctorId == schedule.DoctorId && y.Date == schedule.Date));
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);

            var schedules = await _service.Create(scheduleDto);

            Assert.True(schedules.Success);
            Assert.NotNull(schedules.Data);
        }
        [Fact]
        public async void ShouldNotCreateDuplicatedSchedule()
        {
            var scheduleDto = new CreateScheduleDTO
            {
                DoctorId = 1,
                Date = new DateTime(2024, 10, 13, 9, 0, 0)
            };

            var schedule = new Schedule
            {
                DoctorId = scheduleDto.DoctorId,
                Date = scheduleDto.Date
            };

            var a = GetSchedules().Any(y => y.DoctorId == schedule.DoctorId && y.Date == schedule.Date);

            _repositoryMock = new Mock<IScheduleRepository>();
            _repositoryMock.Setup(x => x.CheckIfAlreadyExists(schedule.DoctorId, schedule.Date))
                .Returns(async () => GetSchedules().Any(y => y.DoctorId == schedule.DoctorId && y.Date == schedule.Date));
            _service = new ScheduleAppService(_configurationMock.Object, _repositoryMock.Object);

            var createdSchedule = await _service.Create(scheduleDto);

            Assert.False(createdSchedule.Success);
            Assert.Contains("Schedule already exists.", createdSchedule.ErrorMessages);
        }

        private IEnumerable<Schedule> GetSchedules()
        {
            var schedules = new List<Schedule>{
                new Schedule
                {
                    DoctorId =1,
                    Date = new DateTime(2024, 10, 13, 9, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =1,
                    Date = new DateTime(2024, 10, 13, 10, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =1,
                    Date = new DateTime(2024, 10, 13, 11, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =1,
                    Date = new DateTime(2024, 10, 13, 12, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =1,
                    Date = new DateTime(2024, 10, 13, 13, 0,0),
                    Available = false,
                },
                new Schedule
                {
                    DoctorId =2,
                    Date = new DateTime(2024, 10, 13, 9, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =2,
                    Date = new DateTime(2024, 10, 13, 10, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =2,
                    Date = new DateTime(2024, 10, 13, 11, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =3,
                    Date = new DateTime(2024, 10, 13, 12, 0,0),
                    Available = true,
                },
                new Schedule
                {
                    DoctorId =3,
                    Date = new DateTime(2024, 10, 13, 13, 0,0),
                    Available = true,
                }
            };

            return schedules;
        }
    }
}
