using MediatR;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands
{
    public class DeleteOfficersStatusCommand : IRequest
    {
        public int OfficersStatusId { get; set; }
    }
}
