using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Authority.Validators
{
    public class UpdateAuthorityDtoValidator : AbstractValidator<AuthorityDto>
    {
        public UpdateAuthorityDtoValidator()
        {
            Include(new IAuthorityDtoValidator());

            RuleFor(b => b.AuthorityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

