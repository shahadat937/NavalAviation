using MediatR;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Commands
{
    public class CreateRunningHourCommand : IRequest<BaseCommandResponse>
    {
        public CreateRunningHourDto RunningHourDto { get; set; }
    }
}
