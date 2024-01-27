using FluentValidation;

namespace SchoolManagement.Application.DTOs.EmployeeType.Validators 
{
    public class CreateEmployeeTypeDtoValidator : AbstractValidator<CreateEmployeeTypeDto>
    {
        public CreateEmployeeTypeDtoValidator()
        {
            Include(new IEmployeeTypeDtoValidator());
        }
    }
}
