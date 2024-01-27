using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank.Validators
{
    public class CreateRankDtoValidator : AbstractValidator<CreateRankDto>
    {
        public CreateRankDtoValidator()  
        {
            Include(new IRankDtoValidator()); 
        }
    }
}
