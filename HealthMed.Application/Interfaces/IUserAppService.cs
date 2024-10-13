using HealthMed.Application.DTOs;
using HealthMed.Domain.Entities;
using HealthMed.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<Result<User>> Create(CreateUserDTO dto);
    }
}
