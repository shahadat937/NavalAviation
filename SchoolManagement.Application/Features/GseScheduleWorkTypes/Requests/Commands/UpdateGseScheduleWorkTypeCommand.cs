using MediatR;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands
{
    public class UpdateGseScheduleWorkTypeCommand : IRequest<Unit>
    {
        public GseScheduleWorkTypeDto GseScheduleWorkTypeDto { get; set; }
    }
}
