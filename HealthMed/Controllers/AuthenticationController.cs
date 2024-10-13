using HealthMed.Application.DTOs;
using HealthMed.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _appService;
        public AuthenticationController(IAuthenticationAppService appService)
        {
            _appService = appService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _appService.Login(dto.UserName, dto.Password);

            if(!result.Success) return Unauthorized();

            return Ok(result);
        }
    }
}
