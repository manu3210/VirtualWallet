using FluentValidation.TestHelper;
using VirtualWallet.DTO;
using VirtualWallet.Validations;
using Xunit;

namespace VirtualWallet.UnitTests.Validations
{
    public class UserValidatorTests
    {
        private readonly UserValidator _validator;
        public UserValidatorTests()
        {
            _validator = new UserValidator();
        }

        [Fact]
        public void UserValidator_WhenEmailIsNull_ShouldHaveError()
        {
            var model = new UserDto { Email = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Email);
        }

        [Fact]
        public void UserValidator_WhenEmailIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { Email = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Email);
        }

        [Fact]
        public void UserValidator_WhenEmailIsNotCorrect_ShouldHaveError()
        {
            var model = new UserDto { Email = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Email);
        }

        [Fact]
        public void UserValidator_WhenEmailInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { Email = "test@test.com" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.Email);
        }

        [Fact]
        public void UserValidator_WhenPasswordIsNull_ShouldHaveError()
        {
            var model = new UserDto { Password = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Password);
        }

        [Fact]
        public void UserValidator_WhenPasswordIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { Password = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Password);
        }

        [Fact]
        public void UserValidator_WhenPasswordInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { Password = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.Password);
        }

        [Fact]
        public void UserValidator_WhenUserNameIsNull_ShouldHaveError()
        {
            var model = new UserDto { UserName = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.UserName);
        }

        [Fact]
        public void UserValidator_WhenUserNameIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { UserName = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.UserName);
        }

        [Fact]
        public void UserValidator_WhenUserNameInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { UserName = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.UserName);
        }

        [Fact]
        public void UserValidator_WhenFirstNameIsNull_ShouldHaveError()
        {
            var model = new UserDto { FirstName = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.FirstName);
        }

        [Fact]
        public void UserValidator_WhenFirstNameIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { FirstName = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.FirstName);
        }

        [Fact]
        public void UserValidator_WhenFirstNameInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { FirstName = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.FirstName);
        }

        [Fact]
        public void UserValidator_WhenLastNameIsNull_ShouldHaveError()
        {
            var model = new UserDto { LastName = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.LastName);
        }

        [Fact]
        public void UserValidator_WhenLastNameIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { LastName = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.LastName);
        }

        [Fact]
        public void UserValidator_WhenLastNameInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { LastName = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.LastName);
        }

        [Fact]
        public void UserValidator_WhenDniIsNull_ShouldHaveError()
        {
            var model = new UserDto { Dni = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Dni);
        }

        [Fact]
        public void UserValidator_WhenDniIsEmpty_ShouldHaveError()
        {
            var model = new UserDto { Dni = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Dni);
        }

        [Fact]
        public void UserValidator_WhenDniInNotNullOrEmptyAndIsCorrect_ShouldNotHaveError()
        {
            var model = new UserDto { Dni = "test" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.Dni);
        }
    }
}
