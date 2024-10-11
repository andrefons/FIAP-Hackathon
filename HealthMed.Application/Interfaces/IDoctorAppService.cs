using HealthMed.Application.DTOs;

namespace HealthMed.Application.Interfaces
{
    public interface IDoctorAppService
    {
        Task<IEnumerable<DoctorDTO>> GetAll();
    }
}
