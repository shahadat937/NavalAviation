using FluentValidation;

namespace SchoolManagement.Application.DTOs.Status.Validators 
{
    public class CreateStatusDtoValidator : AbstractValidator<CreateStatusDto>
    {
        public CreateStatusDtoValidator()
        {
            Include(new IStatusDtoValidator());
        }
    }
}
