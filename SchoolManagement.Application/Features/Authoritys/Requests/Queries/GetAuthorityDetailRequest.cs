using MediatR;
using SchoolManagement.Application.DTOs.Authority;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Queries
{
    public class GetAuthorityDetailRequest : IRequest<AuthorityDto>
    {
        public int AuthorityId { get; set; }
    }
}
