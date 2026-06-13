namespace ParkingSystem.Application.DTOs;

public class GenerateResidentQrDto
{
    public Guid UserId { get; set; }

    public TimeSpan Expiration { get; set; }
}