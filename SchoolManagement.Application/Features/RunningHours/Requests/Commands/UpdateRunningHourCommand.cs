using MediatR;
using SchoolManagement.Application.DTOs.RunningHour;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Commands
{
    public class UpdateRunningHourCommand : IRequest<Unit>
    {
        public RunningHourDto RunningHourDto { get; set; }
    }
}
