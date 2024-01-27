using MediatR;

namespace SchoolManagement.Application.Features.Procurements.Requests.Queries
{
    public class GetPendingProcurementSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
