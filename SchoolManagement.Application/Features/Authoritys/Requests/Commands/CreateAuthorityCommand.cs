using MediatR;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Commands
{
    public class CreateAuthorityCommand : IRequest<BaseCommandResponse>
    {
        public CreateAuthorityDto AuthorityDto { get; set; }
    }
}
