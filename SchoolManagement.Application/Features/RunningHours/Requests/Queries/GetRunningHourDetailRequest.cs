using MediatR;
using SchoolManagement.Application.DTOs.RunningHour;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Queries
{
    public class GetRunningHourDetailRequest : IRequest<RunningHourDto>
    {
        public int RunningHourId { get; set; }
    }
}
