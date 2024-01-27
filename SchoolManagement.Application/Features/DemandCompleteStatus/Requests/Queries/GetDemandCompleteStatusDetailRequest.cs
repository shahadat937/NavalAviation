using MediatR;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries
{
    public class GetDemandCompleteStatusDetailRequest : IRequest<DemandCompleteStatusDto>
    {
        public int DemandCompleteStatusId { get; set; }
    }
}
