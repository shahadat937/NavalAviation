using MediatR;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Commands
{
    public class DeleteItemStatusCommand : IRequest
    {
        public int ItemStatusId { get; set; }
    }
} 
