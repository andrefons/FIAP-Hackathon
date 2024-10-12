namespace HealthMed.Application.DTOs
{
    public class DetailedMedicalAppointmentDTO
    {
        public long Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorCRM { get; set; }
        public string ScheduleDate { get; set; }
    }
}