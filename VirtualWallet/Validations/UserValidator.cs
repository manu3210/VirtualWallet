using FluentValidation;
using VirtualWallet.DTO;

namespace VirtualWallet.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(u => u.Password).NotEmpty().NotNull();
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.Dni).NotNull().NotEmpty();
        }
    }
}
