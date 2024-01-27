using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OfficersStatus.Validators
{
    public class CreateOfficersStatusDtoValidator : AbstractValidator<CreateOfficersStatusDto>
    {
        public CreateOfficersStatusDtoValidator()  
        {
            Include(new IOfficersStatusDtoValidator()); 
        }
    }
}
