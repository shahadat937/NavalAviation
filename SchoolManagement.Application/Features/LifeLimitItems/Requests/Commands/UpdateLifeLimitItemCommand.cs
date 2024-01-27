using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItem;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands
{
    public class UpdateLifeLimitItemCommand : IRequest<Unit>
    {
        public LifeLimitItemDto LifeLimitItemDto { get; set; }
    }
}
