using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Thana.Validators
{
    public class CreateThanaDtoValidator : AbstractValidator<CreateThanaDto>
    {
        public CreateThanaDtoValidator()
        {
            Include(new IThanaDtoValidator());
        }
    }
}
