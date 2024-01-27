using MediatR;
using SchoolManagement.Application.DTOs.Status;

namespace SchoolManagement.Application.Features.Statuses.Requests.Queries
{
    public class GetStatusDetailRequest : IRequest<StatusDto>
    {
        public int StatusId { get; set; }
    }
}
