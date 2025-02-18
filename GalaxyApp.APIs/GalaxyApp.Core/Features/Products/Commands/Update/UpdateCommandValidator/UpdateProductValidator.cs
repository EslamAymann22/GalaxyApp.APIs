using FluentValidation;
using GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandHandler;
using GalaxyApp.Service.Interfaces.ProductInterface;

namespace GalaxyApp.Core.Features.Products.Commands.Update.UpdateCommandValidator
{


    public class UpdateProductValidator : AbstractValidator<UpdateProductModel>
    {
        private readonly IProductService _productService;

        public UpdateProductValidator(IProductService productService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._productService = productService;
        }

        public void ApplyValidationRules()
        {

            RuleFor(P => P.Name).NotEmpty().NotNull();
            RuleFor(P => P.Color).NotEmpty().NotNull();
            RuleFor(P => P.Evaluation).InclusiveBetween(1, 10).NotNull();
            RuleFor(P => P.sellingPrice).ExclusiveBetween(0, int.MaxValue);
            RuleFor(P => P.PurchasingPrice).ExclusiveBetween(0, int.MaxValue);
        }

        public void ApplyCustomValidationRules()
        {
            ////////// Make Wrong and say this id is exist and u can't add this , but i want Just update!!! //////


            //RuleFor(P => P.Id)
            //.MustAsync(async (ProductId, CancellationToken)
            //=> (await _productService.GetByIdAsync(ProductId) is not null))
            //.WithMessage("This Product is not Existed");

            // RuleFor(Pr => Pr).MustAsync(async (prod, CancellationToken) =>
            //(await _productService.GetAllAsync())
            // .Where(
            //     p => p.Name == prod.Name
            //     && p.Color == prod.Color
            //     ).FirstOrDefault()?.Id == prod.Id
            //     || (await _productService.GetAllAsync())
            // .Where(
            //     p => p.Name == prod.Name
            //     && p.Color == prod.Color
            //     ).FirstOrDefault() is null)
            //     .WithMessage("This Product Already Existed");


        }

    }

}

