using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands
{
    public class CreateLifeLimitItemCommand : IRequest<BaseCommandResponse>
    {
        public CreateLifeLimitItemDto LifeLimitItemDto { get; set; }
    }
}
