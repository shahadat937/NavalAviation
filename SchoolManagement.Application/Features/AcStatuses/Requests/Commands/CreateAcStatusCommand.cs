using MediatR;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Commands
{
    public class CreateAcStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateAcStatusDto AcStatusDto { get; set; }
    }
}
