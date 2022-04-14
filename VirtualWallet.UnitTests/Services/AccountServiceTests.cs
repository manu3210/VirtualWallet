using Moq;
using System.Threading.Tasks;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;
using VirtualWallet.Services;
using Xunit;

namespace VirtualWallet.UnitTests.Services
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<IMovementRepository> _movementRepository;

        public AccountServiceTests()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _movementRepository = new Mock<IMovementRepository>();
            _accountService = new AccountService(_accountRepository.Object, _movementRepository.Object);
        }

        [Fact]
        public void Transfer_FromOrToAreNull_ReturnsAStringTheSpecifiedAccountDoesNotExist()
        {
            _accountRepository.Setup(ar => ar.GetAsync(1)).Returns<Account>(null);

            var result = _accountService.Transfer(1, 2, 100);

            Assert.Equal("the specified account does not exist", result.Result);
        }

        [Fact]
        public void Transfer_FromOrToAreNotNullButAmountIsGreaterThanFromBalance_ReturnsAStringNotEnoughMoney()
        {
            _accountRepository.Setup(ar => ar.GetAsync(1)).Returns(new Task<Account>(() => new() { Id = 1, Balance = 1000 }));
            _accountRepository.Setup(ar => ar.GetAsync(2)).Returns(new Task<Account>(() => new() { Id = 2, Balance = 0 }));

            var result = _accountService.Transfer(1, 2, 2000);

            Assert.Equal("Not enough money", result.Result);
        }
        /*
        [Fact]
        public void Transfer_FromOrToAreNotNullAndAmountIsLessThanFromBalance_ReturnsAStringSuccessfulOperation()
        {
            var from = new Account() { Id = 1, Balance = 1000 };
            var to = new Account() { Id = 2, Balance = 0 };

            _accountRepository.Setup(ar => ar.GetAsync(1)).Returns(from);
            _accountRepository.Setup(ar => ar.GetAsync(2)).Returns(to);
            _accountRepository.Setup(ar => ar.Transfer(from, to, 500)).Returns("Successful operation");

            var result = _accountService.Transfer(1, 2, 500);

            Assert.Equal("Successful operation", result);
        }

        [Fact]
        public void AddMoney_CardPassedIsOutOfDate_ReturnsAStringYourCardIsNotAvailable()
        {
            var result = _accountService.AddMoney(1, 100, "1234", 2, 20);

            Assert.Equal("Your card is not available", result);
        }

        [Fact]
        public void AddMoney_CardAndAmountAreCorrectButTheAccountDoesNotExist_ReturnsAStringSomethingWentWrong()
        {
            _accountRepository.Setup(ar => ar.Get(1)).Returns<Account>(null);

            var result = _accountService.AddMoney(1, 100, "1234", 2, 30);

            Assert.Equal("Something went wrong", result);
        }

        [Fact]
        public void AddMoney_CardIsCorrectTheAccountExistButAmountIsLessThanZero_ReturnsAStringSomethingWentWrong()
        {
            _accountRepository.Setup(ar => ar.Get(1)).Returns(new Account() { Id = 1 });

            var result = _accountService.AddMoney(1, -100, "1234", 2, 30);

            Assert.Equal("Something went wrong", result);

        }

        [Fact]
        public void AddMoney_CardIsCorrectTheAccountExistAndAmountIsGreaterThanZero_ReturnsAStringSuccessfulOperation()
        {
            var account = new Account() { Id = 1 };
            _accountRepository.Setup(ar => ar.Get(1)).Returns(account);
            _accountRepository.Setup(ar => ar.AddMoney(account, 100)).Returns("Successful operation");

            var result = _accountService.AddMoney(1, 100, "1234321012343210", 2, 30);

            Assert.Equal("Successful operation", result);

        }
        */
    }
}