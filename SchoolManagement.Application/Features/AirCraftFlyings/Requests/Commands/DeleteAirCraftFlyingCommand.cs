using MediatR;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Commands
{
    public class DeleteAirCraftFlyingCommand : IRequest
    {
        public int AirCraftFlyingId { get; set; }
    }
}
