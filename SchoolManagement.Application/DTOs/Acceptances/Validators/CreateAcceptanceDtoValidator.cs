using FluentValidation;

namespace SchoolManagement.Application.DTOs.Acceptances.Validators
{
    public class CreateAcceptanceDtoValidator : AbstractValidator<CreateAcceptanceDto>
    {
        public CreateAcceptanceDtoValidator()
        {
            Include(new IAcceptanceDtoValidator());
        }
    }
}
 