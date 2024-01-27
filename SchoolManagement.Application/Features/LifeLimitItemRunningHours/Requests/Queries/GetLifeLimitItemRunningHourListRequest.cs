using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries
{
    public class GetLifeLimitItemRunningHourListRequest : IRequest<PagedResult<LifeLimitItemRunningHourDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
