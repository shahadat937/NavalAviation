using MediatR;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands
{
    public class CreateGseScheduleWorkTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateGseScheduleWorkTypeDto GseScheduleWorkTypeDto { get; set; }
    }
}
