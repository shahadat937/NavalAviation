using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands
{
    public class UpdateAirCraftFlyingCommand : IRequest<Unit>
    {
        public AirCraftFlyingDto AirCraftFlyingDto { get; set; }
    }
}
