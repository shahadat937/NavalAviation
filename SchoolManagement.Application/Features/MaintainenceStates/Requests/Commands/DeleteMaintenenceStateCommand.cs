using MediatR;

namespace SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands
{
    public class DeleteMaintenenceStateCommand : IRequest
    {
        public int MaintenenceStateId { get; set; }
    }
} 
