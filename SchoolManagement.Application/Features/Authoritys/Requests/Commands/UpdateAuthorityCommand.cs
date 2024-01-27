using MediatR;
using SchoolManagement.Application.DTOs.Authority;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Commands
{
    public class UpdateAuthorityCommand : IRequest<Unit>
    {
        public AuthorityDto AuthorityDto { get; set; }
    }
}
