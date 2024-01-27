using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetAirCraftNameDetailRequest : IRequest<AirCraftNameDto>
    {
        public int AirCraftNameId { get; set; }
    }
}
