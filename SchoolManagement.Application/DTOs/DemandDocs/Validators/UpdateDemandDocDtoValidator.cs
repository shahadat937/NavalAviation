using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandDocs.Validators
{
    public class UpdateDemandDocDtoValidator : AbstractValidator<DemandDocDto>
    {
        public UpdateDemandDocDtoValidator() 
        {
            Include(new IDemandDocDtoValidator());

            RuleFor(b => b.DemandDocId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
