using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Courses;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Courses.Requests.Queries
{
    public class GetCourseListRequest : IRequest<PagedResult<CourseDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
