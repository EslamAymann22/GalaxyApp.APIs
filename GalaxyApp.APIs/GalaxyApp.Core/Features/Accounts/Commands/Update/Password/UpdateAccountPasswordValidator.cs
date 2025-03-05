using FluentValidation;
using GalaxyApp.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApp.Core.Features.Accounts.Commands.Update.Password
{
    public class UpdateAccountPasswordValidator : AbstractValidator<UpdateAccountPasswordModel>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateAccountPasswordValidator(UserManager<AppUser> userManager)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._userManager = userManager;
        }
        public void ApplyValidationRules()
        {
            RuleFor(AP => AP.Email).NotEmpty().NotNull();
            RuleFor(AP => AP.OldPassword).NotEmpty().NotNull();
            RuleFor(AP => AP.NewPassword).NotEmpty().NotNull();
            RuleFor(AP => AP.ConfirmNewPassword).Equal(AP => AP.NewPassword).WithMessage("'ConfirmNewPassword' Must equal 'NewPassword'");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(AP => AP)
            .MustAsync(
                async (Model, CancellationToken)
            => (await _userManager.FindByEmailAsync(Model.Email))
             is not null)
            .WithMessage("This Email Not found");

            RuleFor(AP => AP)
            .MustAsync(
                async (Model, CancellationToken)
            => (await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(Model.Email), Model.OldPassword)))
            .WithMessage("This Password Is Not correct!!");

        }

    }
}
