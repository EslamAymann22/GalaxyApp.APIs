using FluentValidation;
using GalaxyApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Accounts.Queries.Login
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginValidator(UserManager<AppUser> userManager)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._userManager = userManager;
        }


        public void ApplyValidationRules()
        {
            RuleFor(A => A.Email).NotEmpty().NotNull();
            RuleFor(A => A.Password).NotEmpty().NotNull();
        }

        public void ApplyCustomValidationRules()
        {



            RuleFor(A => A)
            .MustAsync(async (Model, CancellationToken)
            => (await _userManager.FindByEmailAsync(Model.Email))
             is not null)
            .WithMessage("This Email Not found");

        }





    }
}
