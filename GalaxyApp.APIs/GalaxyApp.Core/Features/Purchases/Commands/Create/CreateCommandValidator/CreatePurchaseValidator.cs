using FluentValidation;
using GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Core.Features.Purchases.Commands.Create.CreateCommandValidator
{
    public class CreatePurchaseValidator : AbstractValidator<CreatePurchaseModel>
    {

        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;

        public CreatePurchaseValidator(ISupplierService supplierService, IProductService productService)
        {

            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._supplierService = supplierService;
            this._productService = productService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(P => P.SupplierId).NotEmpty().NotNull().WithMessage($"Supplier Id Is Required");
            RuleForEach(P => P.PurchaseItems).ChildRules(Item =>
            {
                Item.RuleFor(I => I.Quantity).GreaterThan(0);
                Item.RuleFor(I => I.ProductId).GreaterThan(0);
                Item.RuleFor(I => I.Discount).InclusiveBetween(0m, 1m);
            });
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(P => P)
            .MustAsync(async (Model, CancellationToken)
            => (await _supplierService.GetByIdAsync(Model.SupplierId))
             is not null)
            .WithMessage("This Supplier Isn't Exist");


            RuleForEach(P => P.PurchaseItems).ChildRules(Item =>
            {
                Item.RuleFor(I => I).MustAsync(async (Model, CancellationToken)
                => (await _productService.GetByIdAsync(Model.ProductId))
                is not null)
                .WithMessage("This Product Isn't Exist");
            });
        }

    }
}

