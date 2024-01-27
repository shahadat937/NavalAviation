using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MeaBlankFormat.Validators
{
    public class UpdateMeaBlankFormatDtoValidator : AbstractValidator<CreateMeaBlankFormatDto>
    {
        public UpdateMeaBlankFormatDtoValidator()
        {
            Include(new IMeaBlankFormatDtoValidator());

            RuleFor(b => b.MeaBlankFormatId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

