using MediatR;
using SchoolManagement.Application.DTOs.Attendence;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Attendences.Requests.Queries
{
    public class GetAttendenceListRequest : IRequest<PagedResult<AttendenceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
