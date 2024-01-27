using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.PrincipalName.Validators
{
    public class UpdatePrincipalNameDtoValidator : AbstractValidator<PrincipalNameDto>
    {
        public UpdatePrincipalNameDtoValidator()
        {
            Include(new IPrincipalNameDtoValidator());

            RuleFor(b => b.PrincipalNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

