using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ArchivingforPublication.Validators
{
    public class CreateArchivingforPublicationDtoValidator : AbstractValidator<CreateArchivingforPublicationDto>
    {
        public CreateArchivingforPublicationDtoValidator()  
        {
            Include(new IArchivingforPublicationDtoValidator()); 
        }
    }
}
