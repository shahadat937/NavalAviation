using MediatR;
using SchoolManagement.Application.DTOs.ProcurementStatus;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries
{
    public class GetProcurementStatusDetailRequest : IRequest<ProcurementStatusDto>
    {
        public int ProcurementStatusId { get; set; }
    }
}
