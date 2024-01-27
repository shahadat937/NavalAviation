using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandCompleteStatuses.Validators
{
    public class UpdateDemandCompleteStatusDtoValidator : AbstractValidator<DemandCompleteStatusDto>
    {
        public UpdateDemandCompleteStatusDtoValidator() 
        {
            Include(new IDemandCompleteStatusDtoValidator());

            RuleFor(b => b.DemandCompleteStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
