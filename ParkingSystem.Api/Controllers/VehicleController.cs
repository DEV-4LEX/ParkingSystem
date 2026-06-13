using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Infrastructure.Data;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly AppDbContext _context;

    public VehicleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var vehicles = _context.Vehicles.ToList();
        return Ok(vehicles);
    }

    [HttpPost]
    public IActionResult Create(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(Get),
            new { id = vehicle.Id },
            vehicle);
    }
}
