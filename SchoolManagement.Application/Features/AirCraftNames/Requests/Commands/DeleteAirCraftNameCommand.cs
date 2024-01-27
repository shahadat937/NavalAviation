using MediatR;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Commands
{
    public class DeleteAirCraftNameCommand : IRequest
    {
        public int AirCraftNameId { get; set; }
    }
}
