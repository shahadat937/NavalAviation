using MediatR;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands
{
    public class DeleteLifeLimitItemRunningHourCommand : IRequest
    {
        public int LifeLimitItemRunningHourId { get; set; }
    }
}
