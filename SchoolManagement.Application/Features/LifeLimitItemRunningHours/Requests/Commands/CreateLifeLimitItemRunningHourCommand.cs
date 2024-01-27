using MediatR;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Commands
{
    public class CreateLifeLimitItemRunningHourCommand : IRequest<BaseCommandResponse>
    {
        public CreateLifeLimitItemRunningHourDto LifeLimitItemRunningHourDto { get; set; }
    }
}
