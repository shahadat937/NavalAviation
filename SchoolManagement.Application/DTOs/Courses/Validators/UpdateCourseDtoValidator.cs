using FluentValidation;

namespace SchoolManagement.Application.DTOs.Courses.Validators
{
    public class UpdateCourseDtoValidator : AbstractValidator<CourseDto>
    {
        public UpdateCourseDtoValidator()  
        {
            Include(new ICourseDtoValidator());

            RuleFor(b => b.CourseId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
