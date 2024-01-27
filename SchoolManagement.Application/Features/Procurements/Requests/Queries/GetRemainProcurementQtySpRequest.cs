using MediatR;

namespace SchoolManagement.Application.Features.Procurements.Requests.Queries
{
    public class GetRemainProcurementQtySpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
