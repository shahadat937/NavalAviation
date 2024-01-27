using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAirCraftFlyingDetailRequest : IRequest<AirCraftFlyingDto>
    {
        public int AirCraftFlyingId { get; set; }
    }
}
