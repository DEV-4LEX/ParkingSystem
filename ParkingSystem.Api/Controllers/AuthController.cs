using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Application.DTOs;
using ParkingSystem.Domain.Interfaces;

namespace ParkingSystem.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IQrCodeService _qrCodeService;

    public AuthController(
        IJwtService jwtService,
        IQrCodeService qrCodeService)
    {
        _jwtService = jwtService;
        _qrCodeService = qrCodeService;
    }

    [HttpPost("qrcode")]
    public IActionResult GenerateQrCode(
        GenerateQrRequestDto request)
    {
        var token = _jwtService.GenerateResidentToken(
            request.UserId,
            TimeSpan.FromMinutes(10));

        var qrCodeBytes =
            _qrCodeService.GenerateQrCode(token);

        return File(
            qrCodeBytes,
            "image/png");
    }

    [HttpPost("validate")]
    public IActionResult ValidateQrCode(
        ValidateQrRequestDto request)
    {
        var valid =
            _jwtService.ValidateToken(request.Token);

        if (!valid)
        {
            return BadRequest(new
            {
                valid = false,
                message = "Token inválido ou expirado"
            });
        }

        var userId =
            _jwtService.GetUserId(request.Token);

        return Ok(new
        {
            valid = true,
            userId
        });
    }
}