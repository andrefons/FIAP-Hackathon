using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule> Insert(Schedule schedule);
        Task Update(Schedule schedule);
        Task Delete(long id);
        Task<Schedule> Get(long id);
        Task<IEnumerable<Schedule>> GetAllByDoctorId(long doctorId);
        Task<IEnumerable<Schedule>> GetAllAvailablesByDoctorId(long doctorId);
        Task<bool> CheckIfAlreadyExists(long doctorId, DateTime scheduleDate);
    }
}
