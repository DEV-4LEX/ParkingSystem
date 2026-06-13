namespace ParkingSystem.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }

    public string Plate { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}