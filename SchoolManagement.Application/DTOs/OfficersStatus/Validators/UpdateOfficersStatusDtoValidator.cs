using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OfficersStatus.Validators
{
    public class UpdateOfficersStatusDtoValidator : AbstractValidator<OfficersStatusDto>
    {
        public UpdateOfficersStatusDtoValidator()
        {
            Include(new IOfficersStatusDtoValidator());

            RuleFor(b => b.OfficersStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

