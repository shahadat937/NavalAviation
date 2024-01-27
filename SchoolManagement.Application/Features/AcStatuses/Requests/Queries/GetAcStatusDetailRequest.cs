using MediatR;
using SchoolManagement.Application.DTOs.AcStatus;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Queries
{
    public class GetAcStatusDetailRequest : IRequest<AcStatusDto>
    {
        public int AcStatusId { get; set; }
    }
}
