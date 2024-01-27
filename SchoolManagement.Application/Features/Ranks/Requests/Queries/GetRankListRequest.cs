using MediatR;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Ranks.Requests.Queries
{
    public class GetRankListRequest : IRequest<PagedResult<RankDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
