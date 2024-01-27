using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{
    public class GetAutoCompleteItemNameForSurveyByDepartmentRequest : IRequest<List<SelectedModel>>
    {
        public string NameOfItem { get; set; } 
        public int DepartmentNameId { get; set; } 
    }
}
