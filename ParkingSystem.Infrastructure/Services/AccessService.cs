using Microsoft.EntityFrameworkCore;
using ParkingSystem.Application.DTOs;
using ParkingSystem.Infrastructure.Data;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Infrastructure.Services;

public class AccessService
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;

    public AccessService(AppDbContext context,IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<EntryResponseDto>
    RegisterEntryAsync(EntryRequestDto request)
    {
        var valid =
            _jwtService.ValidateToken(request.QrCode);

        if (!valid)
        {
            return new EntryResponseDto
            {
                Granted = false,
                Message = "QR Code inválido."
            };
        }

        var userId =
            _jwtService.GetUserId(request.QrCode);

        if (userId == null)
        {
            return new EntryResponseDto
            {
                Granted = false,
                Message = "Usuário não encontrado."
            };
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return new EntryResponseDto
            {
                Granted = false,
                Message = "Usuário inexistente."
            };
        }

        var accessLog = new AccessLog
        {
            Id = Guid.NewGuid(),
            TokenId = request.QrCode,
            AccessDate = DateTime.UtcNow,
            Granted = true,
            Reason = "Entrada autorizada"
        };

        _context.AccessLogs.Add(accessLog);

        await _context.SaveChangesAsync();

        return new EntryResponseDto
        {
            Granted = true,
            Message = $"Bem-vindo {user.Name}",
            AccessDate = accessLog.AccessDate
        };
    }
}