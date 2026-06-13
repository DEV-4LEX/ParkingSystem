namespace ParkingSystem.Domain.Interfaces
{
    public interface IQrCodeService
    {
        byte[] GenerateQrCode(string token);

        bool ValidateToken(string token);
    }
}