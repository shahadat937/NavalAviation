using MediatR;
using SchoolManagement.Application.DTOs.Courses;

namespace SchoolManagement.Application.Features.Courses.Requests.Queries
{
    public class GetCourseDetailRequest : IRequest<CourseDto>
    {
        public int CourseId { get; set; }
    }
}
