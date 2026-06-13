namespace ParkingSystem.Domain.Entities;

public class QrToken
{
    public Guid Id { get; set; }

    public string Token { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsUsed { get; set; }

    public DateTime? UsedAt { get; set; }
}