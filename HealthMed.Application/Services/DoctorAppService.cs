using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using HealthMed.Domain.Interfaces;
using HealthMed.Shared;
using Microsoft.Extensions.Configuration;

namespace HealthMed.Application.Services
{
    public class DoctorAppService : IDoctorAppService
    {
        private readonly IConfiguration _config;
        private readonly IPersonRepository _personRepository;
        public DoctorAppService(IConfiguration config, IPersonRepository personRepository)
        {
            _config = config;
            _personRepository = personRepository;
        }
        public async Task<Result<IEnumerable<DoctorDTO>>> GetAll()
        {
            var result = await _personRepository
                .GetAllByPersonType(Domain.Enums.EPersonType.Doctor);

            return new Result<IEnumerable<DoctorDTO>>(
                result?.Select(x => new DoctorDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    CRM = x.CRM,
                }));
        }
    }
}
