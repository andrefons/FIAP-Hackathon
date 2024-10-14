using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using HealthMed.Shared;

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

        public async Task<Result<MedicalAppointment>> Create(CreateMedicalAppointmentDTO dto)
        {
            var patient = await _personRepository.GetPatientById(dto.PatientId);

            if (patient is null) return new Result<MedicalAppointment>().AddErrorMessage("Invalid patient.");

            var doctor = await _personRepository.GetDoctorById(dto.DoctorId);

            if (doctor is null) return new Result<MedicalAppointment>().AddErrorMessage("Invalid doctor.");

            var schedule = await _scheduleRepository.Get(dto.ScheduleId);

            if (schedule is null || !schedule.Available) return new Result<MedicalAppointment>().AddErrorMessage("Appointment date unavailable.");

            var medicalAppointment = await _repository.Insert(new MedicalAppointment
            {
                DoctorId = doctor.Id,
                ScheduleId = schedule.Id,
                PatientId = patient.Id
            });

            schedule.Available = false;
            await _scheduleRepository.Update(schedule);

            if (medicalAppointment.Id > 0)
            {
                var sendResult =
                    await _emailService.SendAsync(
                        doctor.Email,
                        "Health&Med - Nova consulta agendada",
                        EmailTemplates.GetNewMedicalAppointmentEmail(
                            doctor.Name,
                            patient.Name,
                            schedule.Date
                        ));

                if (!sendResult.Success) return new Result<MedicalAppointment>().AddErrorMessage("Doctor notification not sended.");
            }

            return new Result<MedicalAppointment>(
                medicalAppointment);
        }

        public async Task<Result<MedicalAppointment>> Get(long id)
        {
            var result = await _repository.Get(id);

            return new Result<MedicalAppointment>(
                result);
        }
    }
}