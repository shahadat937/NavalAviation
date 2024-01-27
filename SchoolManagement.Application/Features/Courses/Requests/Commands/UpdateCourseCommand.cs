using MediatR;
using SchoolManagement.Application.DTOs.Courses;

namespace SchoolManagement.Application.Features.Courses.Requests.Commands
{
    public class UpdateCourseCommand : IRequest<Unit>
    { 
        public CourseDto CourseDto { get; set; }
    }
}
  