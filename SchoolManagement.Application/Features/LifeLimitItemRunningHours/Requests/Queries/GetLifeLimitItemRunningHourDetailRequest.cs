using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries
{
    public class GetLifeLimitItemRunningHourDetailRequest : IRequest<LifeLimitItemRunningHourDto>
    {
        public int LifeLimitItemRunningHourId { get; set; }
    }
}
