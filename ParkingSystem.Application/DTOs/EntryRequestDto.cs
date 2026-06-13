namespace ParkingSystem.Application.DTOs;

public class EntryRequestDto
{
    public string QrCode { get; set; } = string.Empty;

    public string? Plate { get; set; }
}