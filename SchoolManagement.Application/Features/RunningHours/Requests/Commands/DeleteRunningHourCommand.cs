using MediatR;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Commands
{
    public class DeleteRunningHourCommand : IRequest
    {
        public int RunningHourId { get; set; }
    }
}
