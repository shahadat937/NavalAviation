using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.RetirementType.Validators
{
    public class UpdateRetirementTypeDtoValidator : AbstractValidator<RetirementTypeDto>
    {
        public UpdateRetirementTypeDtoValidator()
        {
            Include(new IRetirementTypeDtoValidator());

            RuleFor(b => b.RetirementTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

