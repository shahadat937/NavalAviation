using FluentValidation;

namespace SchoolManagement.Application.DTOs.AcStatus.Validators 
{
    public class UpdateAcStatusDtoValidator : AbstractValidator<AcStatusDto>
    {
        public UpdateAcStatusDtoValidator() 
        {
            Include(new IAcStatusDtoValidator());

            RuleFor(b => b.AcStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
