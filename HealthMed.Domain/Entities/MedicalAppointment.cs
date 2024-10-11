namespace HealthMed.Domain.Entities
{
    public class MedicalAppointment : Entity
    {
        public long ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public long DoctorId { get; set; }
        public Person Doctor { get; set; }
        public long PacientId { get; set; }
        public Person Pacient { get; set; }
    }
}
