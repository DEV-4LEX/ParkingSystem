namespace ParkingSystem.Application.DTOs;

public class GenerateGuestQrDto
{
    public Guid InvitationId { get; set; }

    public TimeSpan Expiration { get; set; }
}