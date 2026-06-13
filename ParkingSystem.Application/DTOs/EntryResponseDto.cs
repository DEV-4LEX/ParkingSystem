namespace ParkingSystem.Application.DTOs;

public class EntryResponseDto
{
    public bool Granted { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime AccessDate { get; set; }
}