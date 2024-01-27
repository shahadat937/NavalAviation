using MediatR;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Commands
{
    public class CreatePrincipalNameCommand : IRequest<BaseCommandResponse>
    {
        public CreatePrincipalNameDto PrincipalNameDto { get; set; }
    }
}
