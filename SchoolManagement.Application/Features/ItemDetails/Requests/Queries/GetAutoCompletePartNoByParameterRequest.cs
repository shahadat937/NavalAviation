using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetAutoCompletePartNoByParameterRequest : IRequest<List<SelectedModel>>
    {
        public string PartNo { get; set; } 
        public int DepartmentNameId { get; set; } 
        public int SpareCategoryId { get; set; } 
    }
}
