using FluentValidation;
using SchoolManagement.Application.DTOs.Coursees;

namespace SchoolManagement.Application.DTOs.Courses.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            Include(new ICourseDtoValidator());
        }
    }
} 
 