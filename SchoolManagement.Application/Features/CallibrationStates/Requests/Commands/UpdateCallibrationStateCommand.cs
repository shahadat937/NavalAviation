using MediatR;
using SchoolManagement.Application.DTOs.CallibrationState;

namespace SchoolManagement.Application.Features.CallibrationStates.Requests.Commands
{
    public class UpdateCallibrationStateCommand : IRequest<Unit>
    { 
        public CallibrationStateDto CallibrationStateDto { get; set; }
    }
}
 