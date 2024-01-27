using MediatR;
using SchoolManagement.Application.DTOs.ItemStatuses;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Queries
{
    public class GetItemStatusDetailRequest : IRequest<ItemStatusDto>
    {
        public int ItemStatusId { get; set; }
    }
}
