using MediatR;

namespace SchoolManagement.Application.Features.Courses.Requests.Commands
{
    public class DeleteCourseCommand : IRequest
    {
        public int CourseId { get; set; }
    }
} 
