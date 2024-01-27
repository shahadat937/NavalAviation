using MediatR;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAirCraftFlyingSpRequest : IRequest<object>
    {
        public DateTime? Current { get; set; }
        public int DepartmentId { get; set; }
    }
}
