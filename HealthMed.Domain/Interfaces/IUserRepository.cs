using HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByLogin(string userName, string password);
        Task<bool> CheckIfUserNameAlreadyExists(string userName);
        Task<User> Insert(User user);
        Task Update(User user);
    }
}
