using MediatR;
using SchoolManagement.Application.DTOs.ItemStatuses;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Commands
{
    public class UpdateItemStatusCommand : IRequest<Unit>
    { 
        public ItemStatusDto ItemStatusDto { get; set; }
    }
}
