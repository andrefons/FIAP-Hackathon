namespace HealthMed.Application.DTOs
{
    public class CreateMedicalAppointmentDTO
    {
        public long ScheduleId { get; set; }
        public long DoctorId { get; set; }
        public long PatientId { get; set; }
    }
}