using FluentValidation;
using GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandHandler;
using GalaxyApp.Service.Interfaces;

namespace GalaxyApp.Core.Features.Suppliers.Commands.Create.CreateCommandValidator
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierModel>
    {
        private readonly ISupplierService _supplierService;

        public CreateSupplierValidator(ISupplierService supplierService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this._supplierService = supplierService;
        }

        void ApplyValidationRules()
        {
            RuleFor(P => P.Name).NotEmpty().NotNull().WithMessage($"Name must not be empty or null");
        }

        void ApplyCustomValidationRules()
        {
            RuleFor(P => P.Name)
            .MustAsync(async (Model, supplier, CancellationToken)
            => (await _supplierService.GetAllAsync())
            .Where(P => P.Name == Model.Name).FirstOrDefault() is null)
            .WithMessage("This Product Already Existed");
        }



    }
}
