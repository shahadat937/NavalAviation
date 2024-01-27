using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.NameofPublication.Validators
{
    public class UpdateNameofPublicationDtoValidator : AbstractValidator<NameofPublicationDto>
    {
        public UpdateNameofPublicationDtoValidator()
        {
            Include(new INameofPublicationDtoValidator());

            RuleFor(b => b.NameofPublicationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

