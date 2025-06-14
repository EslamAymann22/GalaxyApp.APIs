using FluentValidation;

namespace GalaxyApp.Core.Features.Accounts.Commands.Create
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountModel>
    {
        public CreateAccountValidator()
        {


            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(A => A.Email).NotEmpty().NotNull();
            RuleFor(A => A.UserName).NotEmpty().NotNull();
            RuleFor(A => A.Password).NotEmpty().NotNull();
            RuleFor(A => A.PasswordConfirmed).Equal(A => A.Password).WithMessage("'PasswordConfirmed' Must be Equal 'Password'");
        }

        public void ApplyCustomValidationRules()
        {

        }



    }
}
