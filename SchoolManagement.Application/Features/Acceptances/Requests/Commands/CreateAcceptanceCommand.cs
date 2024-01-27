using MediatR;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Commands
{
    public class CreateAcceptanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateAcceptanceDto AcceptanceDto { get; set; }
    }
}
