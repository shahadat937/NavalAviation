using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{
    public class GetSelectedItemDetailForSurveyRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }
    }
}
