using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Caste.Validators
{
    public class CreateCasteDtoValidator : AbstractValidator<CreateCasteDto>
    {
        public CreateCasteDtoValidator()
        {
            Include(new ICasteDtoValidator());
        }
    }
}
