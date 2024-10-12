using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentAppService _appService;
        public MedicalAppointmentController(IMedicalAppointmentAppService appService)
        {
            _appService = appService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicalAppointmentDTO dto)
        {
            var result = await _appService.Create(dto);

            if (result is null) return BadRequest();

            return Created();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _appService.Get(id);

            if (result is null) return NotFound();

            return Ok(result);
        }
    }
}