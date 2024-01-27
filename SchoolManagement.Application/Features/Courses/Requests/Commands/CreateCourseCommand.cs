using MediatR;
using SchoolManagement.Application.DTOs.Coursees;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Courses.Requests.Commands
{
    public class CreateCourseCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDto CourseDto { get; set; }
    }
}
