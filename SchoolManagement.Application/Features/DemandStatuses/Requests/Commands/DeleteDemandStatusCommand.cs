using MediatR;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Commands
{
    public class DeleteDemandStatusCommand : IRequest
    {
        public int DemandStatusId { get; set; }
    }
}
