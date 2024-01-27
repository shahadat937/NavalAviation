using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RetirementType.Validators
{
    public class CreateRetirementTypeDtoValidator : AbstractValidator<CreateRetirementTypeDto>
    {
        public CreateRetirementTypeDtoValidator()  
        {
            Include(new IRetirementTypeDtoValidator()); 
        }
    }
}
