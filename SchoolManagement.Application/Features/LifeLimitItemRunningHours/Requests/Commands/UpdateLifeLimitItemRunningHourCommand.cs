using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands
{
    public class UpdateLifeLimitItemRunningHourCommand : IRequest<Unit>
    {
        public LifeLimitItemRunningHourDto LifeLimitItemRunningHourDto { get; set; }
    }
}
