using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;

namespace HealthMed.Application.Interfaces
{
    public interface IMedicalAppointmentAppService
    {
        Task<MedicalAppointment> Create(CreateMedicalAppointmentDTO dto);
        Task<MedicalAppointment> Get(long id);
    }
}