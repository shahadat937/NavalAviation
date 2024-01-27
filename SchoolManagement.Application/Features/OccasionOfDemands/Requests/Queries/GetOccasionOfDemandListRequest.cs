using MediatR;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries
{
    public class GetOccasionOfDemandListRequest : IRequest<PagedResult<OccasionOfDemandDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
