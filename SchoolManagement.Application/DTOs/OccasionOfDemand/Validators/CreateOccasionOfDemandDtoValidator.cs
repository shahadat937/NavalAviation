using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OccasionOfDemand.Validators
{
    public class CreateOccasionOfDemandDtoValidator : AbstractValidator<CreateOccasionOfDemandDto>
    {
        public CreateOccasionOfDemandDtoValidator()  
        {
            Include(new IOccasionOfDemandDtoValidator()); 
        }
    }
}
