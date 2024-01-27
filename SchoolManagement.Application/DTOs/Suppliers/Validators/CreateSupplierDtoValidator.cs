using FluentValidation;

namespace SchoolManagement.Application.DTOs.Suppliers.Validators
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            Include(new ISupplierDtoValidator());
        }
    }
}
 