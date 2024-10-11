using HealthMed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<TokenDTO> Login(string username, string password);
    }
}
