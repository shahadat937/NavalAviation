using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ToolsLocation.Validators
{
    public class IToolsLocationDtoValidator : AbstractValidator<IToolsLocationDto>
    {
        public IToolsLocationDtoValidator() 
        {
            RuleFor(b => b.ToolsLocationName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
