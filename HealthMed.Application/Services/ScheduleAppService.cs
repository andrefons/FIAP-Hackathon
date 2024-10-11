using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Services
{
    public class ScheduleAppService : IScheduleAppService
    {
        private readonly IConfiguration _config;
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleAppService(IConfiguration config, IScheduleRepository scheduleRepository)
        {
            _config = config;
            _scheduleRepository = scheduleRepository;
        }
        public async Task<Schedule> Create(CreateScheduleDTO dto)
        {
            var schedule = new Schedule()
            {
                DoctorId = dto.DoctorId,
                Date = dto.Date,
            };

            var scheduleAlreadyExistis = await _scheduleRepository.CheckIfAlreadyExists(schedule);

            if (scheduleAlreadyExistis) return null;

            await _scheduleRepository.Insert(schedule);

            return schedule;
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScheduleDTO>> GetAllByDoctorId(long doctorId)
        {
            var result = await _scheduleRepository.GetAllByDoctorId(doctorId);

            return result?.Select(x => new ScheduleDTO
            {
                Id = x.Id,
                Date = x.Date,
                DoctorId = x.DoctorId,
            });
        }
        public async Task<IEnumerable<ScheduleDTO>> GetAllAvailablesByDoctorId(long doctorId)
        {
            var result = await _scheduleRepository.GetAllAvailablesByDoctorId(doctorId);

            return result?.Select(x => new ScheduleDTO
            {
                Id = x.Id,
                Date = x.Date,
                DoctorId = x.DoctorId,
            });
        }

        public Task Update(UpdateScheduleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
