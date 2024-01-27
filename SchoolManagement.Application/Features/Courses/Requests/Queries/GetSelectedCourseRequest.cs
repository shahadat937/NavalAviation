using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Courses.Requests.Queries
{
    public class GetSelectedCourseRequest : IRequest<List<SelectedModel>>
    {
    }
} 
