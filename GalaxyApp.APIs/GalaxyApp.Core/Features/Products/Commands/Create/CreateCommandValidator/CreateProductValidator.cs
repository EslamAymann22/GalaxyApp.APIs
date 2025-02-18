using FluentValidation;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;

namespace GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandValidator
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(P => P.Name).NotEmpty().NotNull().WithMessage($"must not be empty or null");
            RuleFor(P => P.Color).NotEmpty().NotNull().WithMessage($"must not be empty or null");
            RuleFor(P => P.Evaluation).InclusiveBetween(1, 10).NotNull().WithMessage($"Must between 1 and 10 inclusive");
            RuleFor(P => P.sellingPrice).ExclusiveBetween(0, int.MaxValue).WithMessage($"must be positive number");
            RuleFor(P => P.PurchasingPrice).ExclusiveBetween(0, int.MaxValue).WithMessage($"must be positive number");

        }


    }
}
