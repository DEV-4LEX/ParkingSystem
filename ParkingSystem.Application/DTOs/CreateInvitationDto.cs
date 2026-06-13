namespace ParkingSystem.Application.DTOs;

public class CreateInvitationDto
{
    public string GuestName { get; set; } = string.Empty;

    public Guid ResidentId { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsSingleUse { get; set; }
}