using MediatR;
using SchoolManagement.Application.DTOs.OfficersStatus;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries
{
    public class GetOfficersStatusDetailRequest : IRequest<OfficersStatusDto>
    {
        public int OfficersStatusId { get; set; }
    }
}
