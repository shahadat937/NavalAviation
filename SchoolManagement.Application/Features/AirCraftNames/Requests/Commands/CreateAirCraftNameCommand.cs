using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Commands
{
    public class CreateAirCraftNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateAirCraftNameDto AirCraftNameDto { get; set; }
    }
}
