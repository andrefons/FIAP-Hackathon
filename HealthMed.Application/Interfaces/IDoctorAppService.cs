using HealthMed.Application.DTOs;
using HealthMed.Shared;

namespace HealthMed.Application.Interfaces
{
    public interface IDoctorAppService
    {
        Task<Result<IEnumerable<DoctorDTO>>> GetAll();
    }
}
