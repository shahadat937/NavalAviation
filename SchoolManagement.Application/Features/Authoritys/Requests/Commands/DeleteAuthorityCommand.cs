using MediatR;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Commands
{
    public class DeleteAuthorityCommand : IRequest
    {
        public int AuthorityId { get; set; }
    }
}
