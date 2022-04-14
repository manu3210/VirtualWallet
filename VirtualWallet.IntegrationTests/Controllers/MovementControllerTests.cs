using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using VirtualWallet.Models;
using Xunit;

namespace VirtualWallet.IntegrationTests.Controllers
{
    public class MovementControllerTests : IClassFixture<CustomAppFactory<Program>>
    {
        private readonly CustomAppFactory<Program> _customAppFactory;
        private readonly HttpClient _client;

        public MovementControllerTests(CustomAppFactory<Program> factory)
        {
            _customAppFactory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async void Details_WhenIdIsNull_ReturnsNotFound()
        {
            var result = await _client.GetAsync("Movements/Details/");
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void Details_WhenMovementIsNotExist_ReturnsNotFound()
        {
            var result = await _client.GetAsync("Movements/Details/1000");
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void Details_WhenMovementExist_ReturnsOk()
        {
            var result = await _client.GetAsync("Movements/Details/1");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async void Edit_WhenMovementExist_ReturnsOk()
        {
            var result = await _client.PutAsJsonAsync("Movements/Edit/1", new Movements { Id = 1, remarks = "hello" });
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async void Edit_WhenMovementDoesNotExist_ReturnsNotFound()
        {
            var result = await _client.PutAsJsonAsync("Movements/Edit/1000", new Movements { Id = 1000, remarks = "hello" });
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }


    }
}
