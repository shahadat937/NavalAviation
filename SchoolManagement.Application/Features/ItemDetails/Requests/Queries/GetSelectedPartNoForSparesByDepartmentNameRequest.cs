using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetSelectedPartNoForSparesByDepartmentNameRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; } 
        public int SpareCategoryId { get; set; } 
    }
}   
