using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Application.DTOs;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Infrastructure.Services;

namespace ParkingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly AccessService _service;

        public AccessController(AccessService service)
        {
            _service = service;
        }

        [HttpPost("entry")]
        public async Task<IActionResult> RegisterEntry(EntryRequestDto request)
        {
            var result = await _service.RegisterEntryAsync(request);
            return Ok(result);
        }
    }
}