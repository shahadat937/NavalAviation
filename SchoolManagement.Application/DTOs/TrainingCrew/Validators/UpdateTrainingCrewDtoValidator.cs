using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.TrainingCrew.Validators
{
    public class UpdateTrainingCrewDtoValidator : AbstractValidator<TrainingCrewDto>
    {
        public UpdateTrainingCrewDtoValidator()
        {
            Include(new ITrainingCrewDtoValidator());

            RuleFor(b => b.TrainingCrewId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

