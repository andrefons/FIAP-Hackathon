using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Infrastructure.Data.Repositories
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        HealthMedDbContext _context;
        public MedicalAppointmentRepository(HealthMedDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalAppointment> Get(long id)
        {
            var result = await _context.MedicalAppointments
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<IEnumerable<MedicalAppointment>> GetAllByPatient(long patientId)
        {
            var result = await _context.MedicalAppointments
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return result;
        }

        public async Task<MedicalAppointment> Insert(MedicalAppointment medicalAppointment)
        {
            await _context.MedicalAppointments.AddAsync(medicalAppointment);
            await _context.SaveChangesAsync();

            return medicalAppointment;
        }

        public async Task Update(MedicalAppointment medicalAppointment)
        {
            await Task.Run(() => _context.MedicalAppointments.Update(medicalAppointment));
            await _context.SaveChangesAsync();
        }
    }
}