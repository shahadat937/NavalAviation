using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DegitalArchieveDocType.Validators
{
    public class IDegitalArchieveDocTypeDtoValidator : AbstractValidator<IDegitalArchieveDocTypeDto>
    {
        public IDegitalArchieveDocTypeDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
