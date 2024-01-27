using MediatR;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Commands
{
    public class DeleteAcStatusCommand : IRequest
    {
        public int AcStatusId { get; set; }
    }
} 
