
using FluentValidation;
using SchoolManagement.Application.DTOs.Coursees;

namespace SchoolManagement.Application.DTOs.Courses.Validators
{
    public class ICourseDtoValidator : AbstractValidator<ICourseDto>
    {
        public ICourseDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
