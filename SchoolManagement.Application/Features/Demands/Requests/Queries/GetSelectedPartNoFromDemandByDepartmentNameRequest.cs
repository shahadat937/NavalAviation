using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetSelectedPartNoFromDemandByDepartmentNameRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; } 
        public int SparesCategoryId { get; set; } 
    }
}   
   