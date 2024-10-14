using HealthMed.Domain.Entities;
using HealthMed.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infrastructure.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        HealthMedDbContext _context;
        public ScheduleRepository(HealthMedDbContext context)
        {
            _context = context;
        }
        public async Task<Schedule> Insert(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        public async Task Delete(long id)
        {
            var schedule = await Get(id);

            await Task.Run(() => _context.Schedules.Remove(schedule));
            await _context.SaveChangesAsync();
        }

        public async Task<Schedule> Get(long id)
        {
            var result = await _context.Schedules
                .FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task<IEnumerable<Schedule>> GetAllByDoctorId(long doctorId)
        {
            var result = await _context.Schedules
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();

            return result;
        }
        public async Task<IEnumerable<Schedule>> GetAllAvailablesByDoctorId(long doctorId)
        {
            var result = await _context.Schedules
                .Where(x => x.DoctorId == doctorId && x.Available)
                .ToListAsync();

            return result;
        }
        public async Task Update(Schedule schedule)
        {
            await Task.Run(() => _context.Schedules.Update(schedule));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfAlreadyExists(long doctorId, DateTime date)
        {
            var result = await _context.Schedules
                .AnyAsync(x => x.DoctorId == doctorId && x.Date == date);

            return result;
        }
    }
}
