using MediatR;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Commands
{
    public class DeleteGseScheduleWorkTypeCommand : IRequest
    {
        public int GseScheduleWorkTypeId { get; set; }
    }
}
