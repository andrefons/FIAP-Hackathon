using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;

namespace HealthMed.Application.Services
{
    public class MedicalAppointmentAppService : IMedicalAppointmentAppService
    {
        IMedicalAppointmentRepository _repository;
        IScheduleRepository _scheduleRepository;
        IPersonRepository _personRepository;
        IEmailService _emailService;
        public MedicalAppointmentAppService(
            IMedicalAppointmentRepository repository,
            IScheduleRepository scheduleRepository,
            IPersonRepository personRepository,
            IEmailService emailService)
        {
            _repository = repository;
            _scheduleRepository = scheduleRepository;
            _personRepository = personRepository;
            _emailService = emailService;
        }

        public async Task<MedicalAppointment> Create(CreateMedicalAppointmentDTO dto)
        {
            var patient = await _personRepository.GetPatientById(dto.PatientId);

            if (patient is null) return null;

            var doctor = await _personRepository.GetDoctorById(dto.DoctorId);

            if (doctor is null) return null;

            var schedule = await _scheduleRepository.Get(dto.ScheduleId);

            if (schedule is null || !schedule.Available) return null;

            var medicalAppointment = await _repository.Insert(new MedicalAppointment
            {
                DoctorId = doctor.Id,
                ScheduleId = schedule.Id,
                PatientId = patient.Id
            });

            schedule.Available = false;
            await _scheduleRepository.Update(schedule);

            if (medicalAppointment.Id > 0)
                await _emailService.SendAsync(
                    doctor.Email,
                    "Health&Med - Nova consulta agendada",
                    EmailTemplates.GetNewMedicalAppointmentEmail(
                        doctor.Name,
                        patient.Name,
                        schedule.Date
                    ));

            return medicalAppointment;
        }

        public async Task<MedicalAppointment> Get(long id)
        {
            var result = await _repository.Get(id);

            return result;
        }
    }
}