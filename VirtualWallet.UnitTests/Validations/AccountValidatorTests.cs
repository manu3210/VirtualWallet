using FluentValidation.TestHelper;
using VirtualWallet.DTO;
using VirtualWallet.Validations;
using Xunit;

namespace VirtualWallet.UnitTests.Validations
{
    public class AccountValidatorTests
    {
        private readonly AccountValidator _validator;
        public AccountValidatorTests()
        {
            _validator = new AccountValidator();
        }

        [Fact]
        public void AccountValidator_WhenBrandNameIsNull_ShouldHaveError()
        {
            var model = new AccountDto { Name = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [Fact]
        public void AccountValidator_WhenBrandNameIsNotNull_ShouldNotHaveError()
        {
            var model = new AccountDto { Name = "Test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }
    }
}
