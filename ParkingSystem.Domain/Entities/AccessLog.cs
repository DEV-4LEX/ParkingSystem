namespace ParkingSystem.Domain.Entities;

public class AccessLog
{
    public Guid Id { get; set; }

    public string TokenId { get; set; } = string.Empty;

    public DateTime AccessDate { get; set; }

    public bool Granted { get; set; }

    public string Reason { get; set; } = string.Empty;
}