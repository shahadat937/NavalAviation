using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName;

namespace SchoolManagement.Application.Features.AirCraftNames.Requests.Queries
{
    public class GetAirCraftNameListByDepartmentNameIdRequest : IRequest<List<AirCraftNameDto>>
    {
        //public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
    } 
}

 