using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorAppService _appService;
        private readonly IScheduleAppService _scheduleAppService;
        public DoctorController(IDoctorAppService appService, IScheduleAppService scheduleAppService)
        {
            _appService = appService;
            _scheduleAppService = scheduleAppService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            var result = await _appService.GetAll();

            if (!result.Success) return BadRequest(result.ErrorMessages);

            return Ok(result);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll(){
            var result = await _appService.GetAll();

            if (!result.Success) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}/schedule")]
        public async Task<IActionResult> GetSchedule(long id)
        {
            var result = await _scheduleAppService.GetAllByDoctorId(id);

            if (!result.Success) return NotFound();

            return Ok(result);
        }
        [HttpGet("{id}/available-schedule")]
        public async Task<IActionResult> GetAvailablesSchedules(long id)
        {
            var result = await _scheduleAppService.GetAllAvailablesByDoctorId(id);

            if (!result.Success) return NotFound();

            return Ok(result);
        }
    }
}
