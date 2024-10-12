using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;

namespace HealthMed.Application.Services
{
    public class MedicalAppointmentAppService : IMedicalAppointmentAppService
    {
        public MedicalAppointmentAppService()
        {

        }

        public Task<MedicalAppointment> Create(CreateMedicalAppointmentDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}