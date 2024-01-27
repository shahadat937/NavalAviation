using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsBoxNames.Validators
{
    public class UpdateToolsBoxNameDtoValidator : AbstractValidator<ToolsBoxNameDto>
    {
        public UpdateToolsBoxNameDtoValidator() 
        {
            Include(new IToolsBoxNameDtoValidator());

            RuleFor(b => b.ToolsBoxNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
