using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItem;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries
{
    public class GetLifeLimitItemDetailRequest : IRequest<LifeLimitItemDto>
    {
        public int LifeLimitItemId { get; set; }
    }
}
