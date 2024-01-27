using MediatR;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries
{
    public class GetGseScheduleWorkTypeDetailRequest : IRequest<GseScheduleWorkTypeDto>
    {
        public int GseScheduleWorkTypeId { get; set; }
    }
}
