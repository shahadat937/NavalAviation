using MediatR;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetSpFlyingScheduleRequest : IRequest<object>
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int DepartmentId { get; set; }
    }
}
