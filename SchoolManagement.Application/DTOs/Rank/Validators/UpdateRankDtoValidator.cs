using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Rank.Validators
{
    public class UpdateRankDtoValidator : AbstractValidator<RankDto>
    {
        public UpdateRankDtoValidator()
        {
            Include(new IRankDtoValidator());

            RuleFor(b => b.RankId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

