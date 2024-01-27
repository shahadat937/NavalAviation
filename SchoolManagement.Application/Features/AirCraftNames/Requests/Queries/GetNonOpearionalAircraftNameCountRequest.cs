using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetNonOpearionalAircraftNameCountRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
 