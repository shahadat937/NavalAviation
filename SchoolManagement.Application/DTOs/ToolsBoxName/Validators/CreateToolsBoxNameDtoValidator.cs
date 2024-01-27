using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsBoxNames.Validators
{
    public class CreateToolsBoxNameDtoValidator : AbstractValidator<CreateToolsBoxNameDto>
    {
        public CreateToolsBoxNameDtoValidator()
        {
            Include(new IToolsBoxNameDtoValidator());
        }
    }
}
 