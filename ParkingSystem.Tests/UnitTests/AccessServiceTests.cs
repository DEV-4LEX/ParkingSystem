using ParkingSystem.Application.Services;
using ParkingSystem.Application.DTOs;
using ParkingSystem.Infrastructure.Data;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Tests.ServicesTests
{
    public class AccessServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task RegisterEntry_ShouldReturnUserNotFound()
        {
            // Arrange
            var context = GetDbContext();
            var service = new AccessService(context);

            var request = new EntryRequestDto
            {
                QrCode = "123"
            };

            // Act
            var result = await service.RegisterEntryAsync(request);

            // Assert
            Assert.Equal("Usuário não encontrado.", result);
        }

        [Fact]
        public async Task RegisterEntry_ShouldReturnUserAlreadyInside()
        {
            // Arrange
            var context = GetDbContext();

            var user = new User
            {
                Id = 1,
                Name = "Teste",
                QrCode = "123"
            };

            context.Users.Add(user);

            context.AccessSessions.Add(new AccessSession
            {
                UserId = 1,
                IsClosed = false
            });

            await context.SaveChangesAsync();

            var service = new AccessService(context);

            var request = new EntryRequestDto
            {
                QrCode = "123"
            };

            // Act
            var result = await service.RegisterEntryAsync(request);

            // Assert
            Assert.Equal("Usuário já está dentro.", result);
        }

        [Fact]
        public async Task RegisterEntry_ShouldReturnVehicleNotFound()
        {
            // Arrange
            var context = GetDbContext();

            var user = new User
            {
                Id = 1,
                Name = "Teste",
                QrCode = "123"
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var service = new AccessService(context);

            var request = new EntryRequestDto
            {
                QrCode = "123",
                Plate = "ABC1234"
            };

            // Act
            var result = await service.RegisterEntryAsync(request);

            // Assert
            Assert.Equal("Veículo não encontrado.", result);
        }

        [Fact]
        public async Task RegisterEntry_ShouldRegisterEntrySuccessfully()
        {
            // Arrange
            var context = GetDbContext();

            var user = new User
            {
                Id = 1,
                Name = "Teste",
                QrCode = "123"
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var service = new AccessService(context);

            var request = new EntryRequestDto
            {
                QrCode = "123"
            };

            // Act
            var result = await service.RegisterEntryAsync(request);

            // Assert
            Assert.Equal("Entrada registrada com sucesso.", result);
        }
    }
}