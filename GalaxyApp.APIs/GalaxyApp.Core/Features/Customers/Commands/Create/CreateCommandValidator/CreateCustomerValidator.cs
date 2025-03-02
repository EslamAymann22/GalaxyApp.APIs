using FluentValidation;
using GalaxyApp.Core.Features.Customers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Core.Features.Customers.Commands.Create.CreateCommandValidator
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        private readonly ICustomerServices _customerServices;

        public CreateCustomerValidator(ICustomerServices customerServices)
        {

            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._customerServices = customerServices;
        }


        public void ApplyValidationRules()
        {
            RuleFor(C => C.Name).NotEmpty().NotNull().WithMessage($"Name must not be empty or null");
            RuleFor(C => C.Phone).NotEmpty().NotNull()
                .WithMessage($"Phone must not be empty or null");
            RuleFor(C => C.Phone).MaximumLength(12)
                .MinimumLength(8)
                .WithMessage($"Phone must be between 8 and 12 Digit");

        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(P => P)
            .MustAsync(async (Model, CancellationToken)
            => (await _customerServices.GetByPhoneAsync(Model.Phone))
             is null)
            .WithMessage("This Phone Number Already Existed");
        }
    }
}
