using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Commands
{
    public class UpdateAirCraftNameCommand : IRequest<Unit>
    {
        public CreateAirCraftNameDto CreateAirCraftNameDto { get; set; }
    }
}
