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
    public class UserRepository : IUserRepository
    {
        HealthMedDbContext _context;
        public UserRepository(HealthMedDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByLogin(string userName, string password)
        {
            var result = await _context.Users
                .Include(x => x.Person)
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

            return result;
        }
        public async Task<bool> CheckIfUserNameAlreadyExists(string userName)
        {
            var result = await _context.Users
                .AnyAsync(x => x.UserName == userName);

            return result;
        }

        public async Task<User> Insert(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Update(User user)
        {
            await Task.Run(() => _context.Users.Update(user));
            await _context.SaveChangesAsync();
        }
    }
}
