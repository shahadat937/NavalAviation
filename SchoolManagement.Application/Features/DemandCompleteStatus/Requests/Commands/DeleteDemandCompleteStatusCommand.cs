using MediatR;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands
{
    public class DeleteDemandCompleteStatusCommand : IRequest
    {
        public int DemandCompleteStatusId { get; set; }
    }
} 
