using FluentValidation;
using GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces.ProductInterface;

namespace GalaxyApp.Core.Features.Products.Commands.Create.CreateCommandValidator
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductValidator(IProductService productService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._productService = productService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(P => P.Name).NotEmpty().NotNull().WithMessage($"must not be empty or null");
            RuleFor(P => P.Color).NotEmpty().NotNull().WithMessage($"must not be empty or null");
            RuleFor(P => P.Evaluation).InclusiveBetween(1, 10).NotNull().WithMessage($"Must between 1 and 10 inclusive");
            RuleFor(P => P.sellingPrice).ExclusiveBetween(0, int.MaxValue).WithMessage($"must be positive number");
            RuleFor(P => P.PurchasingPrice).ExclusiveBetween(0, int.MaxValue).WithMessage($"must be positive number");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(P => P)
            .MustAsync(async (Model, Product, CancellationToken)
            => (await _productService.GetAllAsync())
            .Where(P => P.Name == Model.Name && P.Color == Model.Color && P.PurchasingPrice == Model.PurchasingPrice).FirstOrDefault() is null)
            .WithMessage("This Product Already Existed");
        }

    }
}
