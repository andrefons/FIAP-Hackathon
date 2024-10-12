using HealthMed.Domain.Entities;

namespace HealthMed.Domain.Interfaces
{
    public interface IMedicalAppointmentRepository
    {
        Task<MedicalAppointment> Insert(MedicalAppointment medicalAppointment);
        Task Update(MedicalAppointment medicalAppointment);
        Task<MedicalAppointment> Get(long id);
        Task<IEnumerable<MedicalAppointment>> GetAllByPatient(long patientId);
    }
}