using FluentValidation;
using GalaxyApp.Core.Features.TransferDetections.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Core.Features.TransferDetections.Commands.Create.CreateCommandValidator
{
    public class CreateTransferDetectionValidator : AbstractValidator<CreateTransferDetectionModel>
    {
        private readonly IProductService _productService;

        public CreateTransferDetectionValidator(IProductService productService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._productService = productService;
        }

        public void ApplyValidationRules()
        {
            RuleForEach(P => P.Items).ChildRules(TI =>
            {
                TI.RuleFor(I => I.Quantity).GreaterThan(0);
            });

        }
        public void ApplyCustomValidationRules()
        {
            RuleForEach(T => T.Items).ChildRules(Item =>
            {
                Item.RuleFor(I => I).MustAsync(async (Model, CancellationToken)
                => (await _productService.GetByIdAsync(Model.ProductId))
                is not null)
                .WithMessage("This Product Isn't Exist");
            });
        }


    }
}
