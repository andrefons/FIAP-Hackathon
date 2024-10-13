using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleAppService _appService;
        public ScheduleController(IScheduleAppService appService)
        {
            _appService = appService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleDTO dto)
        {
            var result = await _appService.Create(dto);

            if (!result.Success) return BadRequest(result.ErrorMessages);

            return Ok(result);
        }
    }
}
