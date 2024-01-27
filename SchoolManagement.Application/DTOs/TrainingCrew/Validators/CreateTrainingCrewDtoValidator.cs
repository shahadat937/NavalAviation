using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingCrew.Validators
{
    public class CreateTrainingCrewDtoValidator : AbstractValidator<CreateTrainingCrewDto>
    {
        public CreateTrainingCrewDtoValidator()  
        {
            Include(new ITrainingCrewDtoValidator()); 
        }
    }
}
