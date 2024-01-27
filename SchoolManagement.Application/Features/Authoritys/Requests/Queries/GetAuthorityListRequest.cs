using MediatR;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Authoritys.Requests.Queries
{
    public class GetAuthorityListRequest : IRequest<PagedResult<AuthorityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
