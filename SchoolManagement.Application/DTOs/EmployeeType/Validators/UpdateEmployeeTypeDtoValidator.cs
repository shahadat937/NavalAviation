using FluentValidation;

namespace SchoolManagement.Application.DTOs.EmployeeType.Validators 
{
    public class UpdateEmployeeTypeDtoValidator : AbstractValidator<EmployeeTypeDto>
    {
        public UpdateEmployeeTypeDtoValidator() 
        {
            Include(new IEmployeeTypeDtoValidator());

            RuleFor(b => b.EmployeeTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
