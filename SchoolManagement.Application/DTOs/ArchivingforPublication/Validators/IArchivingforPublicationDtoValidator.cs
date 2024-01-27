using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ArchivingforPublication.Validators
{
    public class IArchivingforPublicationDtoValidator : AbstractValidator<IArchivingforPublicationDto>
    {
        public IArchivingforPublicationDtoValidator() 
        {
            RuleFor(b => b.DocumentName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
