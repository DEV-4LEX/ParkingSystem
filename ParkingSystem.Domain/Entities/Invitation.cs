namespace ParkingSystem.Domain.Entities;

public class Invitation
{
    public Guid Id { get; set; }

    public string GuestName { get; set; } = string.Empty;

    public int ResidentId { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsSingleUse { get; set; }

    public bool IsUsed { get; set; }

    public DateTime? UsedAt { get; set; }
}