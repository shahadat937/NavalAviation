using MediatR;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PrincipalNames.Requests.Queries
{
    public class GetPrincipalNameListRequest : IRequest<PagedResult<PrincipalNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
