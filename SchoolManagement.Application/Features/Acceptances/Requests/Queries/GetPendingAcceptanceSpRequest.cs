using MediatR;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetPendingAcceptanceSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
