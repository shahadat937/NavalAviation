using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAirCraftFlyingListByDepartmentNameIdRequest : IRequest<List<AirCraftFlyingDto>>
    {
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
    } 
}

 