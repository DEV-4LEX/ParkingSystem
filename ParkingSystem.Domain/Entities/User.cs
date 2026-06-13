namespace ParkingSystem.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string QrCodeSecret { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Vehicle> Vehicles { get; set; }
        = new List<Vehicle>();
}