using QRCoder;
using ParkingSystem.Domain.Interfaces;


namespace ParkingSystem.Infrastructure.QrCode
{
    public class QrCodeGenerator : IQrCodeService
    {
        public byte[] GenerateQrCode(string token)
        {
            using var generator = new QRCodeGenerator();

            var data = generator.CreateQrCode(
                token,
                QRCodeGenerator.ECCLevel.Q);

            var qr = new PngByteQRCode(data);

            return qr.GetGraphic(20);
        }

        public bool ValidateToken(string token)
        {
            return !string.IsNullOrWhiteSpace(token);
        }
    }
}