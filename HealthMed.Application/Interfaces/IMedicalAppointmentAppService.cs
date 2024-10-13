using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Shared;

namespace HealthMed.Application.Interfaces
{
    public interface IMedicalAppointmentAppService
    {
        Task<Result<MedicalAppointment>> Create(CreateMedicalAppointmentDTO dto);
        Task<Result<MedicalAppointment>> Get(long id);
    }
}