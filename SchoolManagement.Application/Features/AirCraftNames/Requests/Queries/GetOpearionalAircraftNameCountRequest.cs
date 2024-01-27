using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetOpearionalAircraftNameCountRequest : IRequest<object>
    {
     public int DepartmentId { get; set; }
   }
}
