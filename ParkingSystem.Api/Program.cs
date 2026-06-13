using Microsoft.EntityFrameworkCore;
using ParkingSystem.Infrastructure.Data;
using ParkingSystem.Infrastructure.Services;
using ParkingSystem.Infrastructure.Security;
using ParkingSystem.Infrastructure.QrCode;
using ParkingSystem.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IQrCodeService, QrCodeGenerator>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AccessService>();

// JWT Service
builder.Services.AddScoped<IJwtService, JwtTokenGenerator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();