namespace ParkingSystem.Domain.Interfaces
{
    public interface IInvitationService
    {
        Task<string> CreateInvitationAsync(
            Guid residentId,
            string visitorName,
            DateTime expiresAt);
    }
}