using MediatR;
using SchoolManagement.Application.DTOs.Attendence;

namespace SchoolManagement.Application.Features.Attendences.Requests.Queries
{
    public class GetAttendenceDetailRequest : IRequest<AttendenceDto>
    {
        public int AttendenceId { get; set; }
    }
}
