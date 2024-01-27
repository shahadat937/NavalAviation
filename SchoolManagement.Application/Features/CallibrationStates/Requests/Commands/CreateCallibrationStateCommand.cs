using MediatR;
using SchoolManagement.Application.DTOs.CallibrationState;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CallibrationStates.Requests.Commands
{
    public class CreateCallibrationStateCommand : IRequest<BaseCommandResponse>
    {
        public CreateCallibrationStateDto CallibrationStateDto { get; set; }
    }
}
