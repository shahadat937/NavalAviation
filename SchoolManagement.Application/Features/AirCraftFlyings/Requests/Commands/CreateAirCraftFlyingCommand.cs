using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands
{
    public class CreateAirCraftFlyingCommand : IRequest<BaseCommandResponse>
    {
        public CreateAirCraftFlyingDto AirCraftFlyingDto { get; set; }
    }
}
