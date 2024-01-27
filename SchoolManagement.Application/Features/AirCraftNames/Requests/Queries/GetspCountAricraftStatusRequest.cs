using MediatR;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetspCountAricraftStatusRequest : IRequest<object>
    {
        public DateTime? Current { get; set; }
        public int DepartmentId { get; set; }
    }
}
