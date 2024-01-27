using MediatR;
using SchoolManagement.Application.DTOs.DemandStatus;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Queries
{
    public class GetDemandStatusDetailRequest : IRequest<DemandStatusDto>
    {
        public int DemandStatusId { get; set; }
    }
}
