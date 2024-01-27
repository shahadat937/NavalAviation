using MediatR;
using SchoolManagement.Application.DTOs.Acceptances;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Commands
{
    public class UpdateAcceptanceCommand : IRequest<Unit>
    { 
        public CreateAcceptanceDto AcceptanceDto { get; set; } 
    }
}
