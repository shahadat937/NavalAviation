using FluentValidation;

namespace SchoolManagement.Application.DTOs.Suppliers.Validators
{
    public class UpdateSupplierDtoValidator : AbstractValidator<SupplierDto>
    {
        public UpdateSupplierDtoValidator() 
        {
            Include(new ISupplierDtoValidator());

            RuleFor(b => b.SupplierId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
