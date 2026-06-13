namespace ParkingSystem.Application.DTOs;

public class QrTokenPayload
{
    public string TokenId { get; set; } = string.Empty;

    public int UserId { get; set; }

    public string Type { get; set; } = string.Empty;

    public DateTime IssuedAt { get; set; }

    public DateTime ExpiresAt { get; set; }
}