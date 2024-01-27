using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Division.Validators
{
    public class CreateDivisionDtoValidator : AbstractValidator<CreateDivisionDto>
    {
        public CreateDivisionDtoValidator()
        {
            Include(new IDivisionDtoValidator());
        }
    }
}
