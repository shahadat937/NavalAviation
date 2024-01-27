using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MaintainenceStates.Requests.Queries
{
    public class GetMaintenenceStateLisBySearchTextRequest : IRequest<object>
    {
    public int DepartmentNameId { get; set; }
    public string SearchText { get; set; }
    }  
}
