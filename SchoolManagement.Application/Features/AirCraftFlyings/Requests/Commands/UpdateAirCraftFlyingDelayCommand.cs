using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands
{
    public class UpdateAirCraftFlyingDelayCommand : IRequest<Unit>
    {
        public AirCraftFlyingDelayDto AirCraftFlyingDto { get; set; }
    }
}
