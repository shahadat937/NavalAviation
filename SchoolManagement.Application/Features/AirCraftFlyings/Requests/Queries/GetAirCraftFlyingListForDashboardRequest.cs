using MediatR;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAirCraftFlyingListForDashboardRequest : IRequest<List<AirCraftFlyingDto>>
    {
      // public DateTime Date { get; set; }
      public int DepartmentId { get; set; }
    } 
}

