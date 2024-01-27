using MediatR;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetFlyingTimeByAricraftSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
