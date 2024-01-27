using MediatR;
using SchoolManagement.Application.DTOs.MaintenenceState;

namespace SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands
{
    public class UpdateMaintenenceStateCommand : IRequest<Unit>
    { 
        public MaintenenceStateDto MaintenenceStateDto { get; set; }
    }
}
