using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandStatus.Validators
{
    public class UpdateDemandStatusDtoValidator : AbstractValidator<DemandStatusDto>
    {
        public UpdateDemandStatusDtoValidator()
        {
            Include(new IDemandStatusDtoValidator());

            RuleFor(b => b.DemandStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

