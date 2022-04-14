using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Mvc;
using VirtualWallet.DTO;
using VirtualWallet.Models;
using Xunit;

namespace VirtualWallet.IntegrationTests.Controllers
{
    public class AccountControllerTests : IClassFixture<CustomAppFactory<Program>>
    {
        private readonly CustomAppFactory<Program> _customAppFactory;
        private readonly HttpClient _client;

        public AccountControllerTests(CustomAppFactory<Program> factory)
        {
            _customAppFactory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async void Details_WhenIdIsNull_ReturnsNotFound()
        {
            var result = await _client.GetAsync("Accounts/Details/");
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void Details_WhenMovementIsNotExist_ReturnsNotFound()
        {
            var result = await _client.GetAsync("Accounts/Details/1000");
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void Details_WhenMovementExist_ReturnsOk()
        {
            var result = await _client.GetAsync("Accounts/Details/1");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async void Create_WhenAccountToAddIsCorrect_ReturnsOk()
        {
            var result = await _client.PostAsJsonAsync<AccountDto>("Accounts/Create", new AccountDto { Name = "Test", Type = 1 });
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        

    }
}