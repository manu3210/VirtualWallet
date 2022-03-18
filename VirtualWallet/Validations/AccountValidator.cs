using FluentValidation;
using VirtualWallet.DTO;

namespace VirtualWallet.Validations
{
    public class AccountValidator : AbstractValidator<AccountDto>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(15);
        }
    }
}
