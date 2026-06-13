namespace ParkingSystem.Domain.Interfaces
{
    public interface IInvitationRepository
    {
        Task SaveAsync(Entities.Invitation invitation);

        Task<Entities.Invitation?> GetByIdAsync(Guid id);

        Task UpdateAsync(Entities.Invitation invitation);
    }
}