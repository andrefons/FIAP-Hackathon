using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;

namespace HealthMed.Application.Interfaces
{
    public interface IScheduleAppService
    {
        Task<Schedule> Create(CreateScheduleDTO dto);
        Task Update(UpdateScheduleDTO dto);
        Task Delete(long id);
        Task<IEnumerable<ScheduleDTO>> GetAllByDoctorId(long doctorId);
        Task<IEnumerable<ScheduleDTO>> GetAllAvailablesByDoctorId(long doctorId);
    }
}
