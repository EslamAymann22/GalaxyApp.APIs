using FluentValidation;
using GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Core.Features.CustomerInvoices.Commands.Create.CreateCommandValidator
{
    public class CreateCustomerPurchaseValidator : AbstractValidator<CreateCustomerInvoiceModel>
    {
        private readonly ICustomerServices _customerServices;
        private readonly IProductService _productService;

        public CreateCustomerPurchaseValidator(ICustomerServices customerServices
                                              , IProductService productService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._customerServices = customerServices;
            this._productService = productService;
        }

        public void ApplyValidationRules()
        {
            RuleForEach(CPI => CPI.CInvoiceItems).ChildRules(Item =>
            {
                Item.RuleFor(I => I.Quantity).GreaterThan(0);
                Item.RuleFor(I => I.Discount).InclusiveBetween(0, 1);
                Item.RuleFor(I => I.ProductId)
                .MustAsync(async (Model, CancellationToken)
            => (await _productService.GetByIdAsync(Model))
             is not null)
            .WithMessage("This Customer Not found");
            });
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(P => P)
            .MustAsync(async (Model, CancellationToken)
            => (await _customerServices.GetByIdAsync(Model.CustomerId))
             is not null)
            .WithMessage("This Customer Not found");
        }


    }
}
