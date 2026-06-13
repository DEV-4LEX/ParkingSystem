using Xunit;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingSystem.Tests.IntegrationTests
{
    public class VehicleApiTests
    {

        [Fact]
        public async Task Should_Return_ValidVehicle_From_WireMock()
        {
            // Arrange
            var server = WireMockServer.Start();

            server
                .Given(
                    Request.Create()
                        .WithPath("/vehicle/ABC1234")
                        .UsingGet()
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody("{ \"plate\": \"ABC1234\", \"status\": \"valid\" }")
                );

            var client = new HttpClient();

            // Act
            var response = await client.GetAsync(server.Url + "/vehicle/ABC1234");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("valid", content);

            server.Stop();
        }

        [Fact]
        public async Task Should_Return_BlockedVehicle_From_WireMock()
        {
            // Arrange
            var server = WireMockServer.Start();

            server
                .Given(
                    Request.Create()
                        .WithPath("/vehicle/XYZ9999")
                        .UsingGet()
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBody("{ \"plate\": \"XYZ9999\", \"status\": \"blocked\" }")
                );

            var client = new HttpClient();

            // Act
            var response = await client.GetAsync(server.Url + "/vehicle/XYZ9999");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("blocked", content);

            server.Stop();
        }
    }
}