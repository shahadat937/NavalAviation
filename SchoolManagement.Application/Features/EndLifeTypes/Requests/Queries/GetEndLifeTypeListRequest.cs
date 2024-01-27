using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.EndLifeTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries
{
    public class GetEndLifeTypeListRequest : IRequest<PagedResult<EndLifeTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
