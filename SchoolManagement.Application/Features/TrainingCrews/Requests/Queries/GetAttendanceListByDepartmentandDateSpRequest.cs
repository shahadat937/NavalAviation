using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetAttendanceListByDepartmentandDateSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
        public int OfficerStatusId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string SearchText { get; set; }
    }
}
