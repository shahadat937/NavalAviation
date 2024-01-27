using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetPendingDemandSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
