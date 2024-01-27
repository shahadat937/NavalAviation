using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DegitalArchieve.Validators
{
    public class UpdateDegitalArchieveDtoValidator : AbstractValidator<CreateDegitalArchieveDto>
    {
        public UpdateDegitalArchieveDtoValidator()
        {
            Include(new IDegitalArchieveDtoValidator());

            RuleFor(b => b.DegitalArchieveId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

