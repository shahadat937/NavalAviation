using MediatR;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries
{
    public class GetOfficersStatusListRequest : IRequest<PagedResult<OfficersStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
