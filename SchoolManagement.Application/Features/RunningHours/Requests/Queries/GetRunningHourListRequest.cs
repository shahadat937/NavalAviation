using MediatR;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Queries
{
    public class GetRunningHourListRequest : IRequest<PagedResult<RunningHourDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
