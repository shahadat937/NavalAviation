using SchoolManagement.Application.DTOs.SailorRank;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Queries
{
    public class GetSailorRankListRequest : IRequest<PagedResult<SailorRankDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
