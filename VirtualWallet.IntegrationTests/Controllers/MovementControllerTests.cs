using System.Net.Http;
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

    }
}
