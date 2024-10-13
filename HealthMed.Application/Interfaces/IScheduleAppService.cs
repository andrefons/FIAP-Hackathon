using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Shared;

namespace HealthMed.Application.Interfaces
{
    public interface IScheduleAppService
    {
        Task<Result<Schedule>> Create(CreateScheduleDTO dto);
        Task<Result> Update(UpdateScheduleDTO dto);
        Task<Result> Delete(long id);
        Task<Result<IEnumerable<ScheduleDTO>>> GetAllByDoctorId(long doctorId);
        Task<Result<IEnumerable<ScheduleDTO>>> GetAllAvailablesByDoctorId(long doctorId);
    }
}
