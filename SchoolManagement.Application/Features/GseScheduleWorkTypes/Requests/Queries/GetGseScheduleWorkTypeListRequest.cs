using MediatR;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries
{
    public class GetGseScheduleWorkTypeListRequest : IRequest<PagedResult<GseScheduleWorkTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
