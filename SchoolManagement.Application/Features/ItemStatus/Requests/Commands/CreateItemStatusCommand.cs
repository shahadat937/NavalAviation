using MediatR;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Commands
{
    public class CreateItemStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemStatusDto ItemStatusDto { get; set; }
    }
}
