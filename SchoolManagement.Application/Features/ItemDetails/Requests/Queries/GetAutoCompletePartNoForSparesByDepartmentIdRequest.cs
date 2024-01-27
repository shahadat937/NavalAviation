using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetAutoCompletePartNoForSparesByDepartmentIdRequest : IRequest<List<SelectedModel>>
    {
        public string PartNo { get; set; } 
        public int DepartmentNameId { get; set; } 
    }
}
