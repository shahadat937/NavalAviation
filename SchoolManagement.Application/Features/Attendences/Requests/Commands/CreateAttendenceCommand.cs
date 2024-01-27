using MediatR;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Attendences.Requests.Commands
{
    public class CreateAttendenceCommand : IRequest<BaseCommandResponse>
    {
        public CreateAttendanceListDto AttendenceDto { get; set; }
    }
}
