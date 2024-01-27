using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ArchivingforPublication.Validators
{
    public class UpdateArchivingforPublicationDtoValidator : AbstractValidator<CreateArchivingforPublicationDto>
    {
        public UpdateArchivingforPublicationDtoValidator()
        {
            Include(new IArchivingforPublicationDtoValidator());

            RuleFor(b => b.ArchivingforPublicationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

