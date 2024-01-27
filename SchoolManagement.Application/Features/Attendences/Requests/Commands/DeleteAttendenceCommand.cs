using MediatR;

namespace SchoolManagement.Application.Features.Attendences.Requests.Commands
{
    public class DeleteAttendenceCommand : IRequest
    {
        public int AttendenceId { get; set; }
    }
}
