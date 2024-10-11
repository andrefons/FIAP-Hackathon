using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _appService;
        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            var result = await _appService.Create(dto);

            if (result is null) return BadRequest();

            return Ok(result);
        }
    }
}
