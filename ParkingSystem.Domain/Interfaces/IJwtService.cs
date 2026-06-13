namespace ParkingSystem.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateResidentToken(
            Guid userId,
            TimeSpan expiration);

        string GenerateGuestToken(
            Guid invitationId,
            TimeSpan expiration);

        bool ValidateToken(string token);

        Guid? GetUserId(string token);

        Guid? GetInvitationId(string token);
    }
}