using MediatR;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetSpGetCompleteStatusRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
