using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.Interfaces;
using HealthMed.Application.Services;
using HealthMed.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;

namespace HealthMed.Tests.Application
{
    public class MedicalAppointmentAppServiceTest
    {
        private Mock<IConfiguration> _configurationMock;
        private Mock<IMedicalAppointmentRepository> _repositoryMock;
        private Mock<IScheduleRepository> _scheduleRepositoryMock;
        private Mock<IPersonRepository> _personRepositoryMock;
        private Mock<IEmailService> _emailServiceMock;
        private IMedicalAppointmentAppService _service;        
        public MedicalAppointmentAppServiceTest()
        {
            _configurationMock = new Mock<IConfiguration>();
            _repositoryMock = new Mock<IMedicalAppointmentRepository>();
            _scheduleRepositoryMock = new Mock<IScheduleRepository>();
            _personRepositoryMock = new Mock<IPersonRepository>();
            _emailServiceMock = new Mock<IEmailService>();
            _service = new MedicalAppointmentAppService(
                _repositoryMock.Object,
                _scheduleRepositoryMock.Object,
                _personRepositoryMock.Object,
                _emailServiceMock.Object);
        }
    }
}
