using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompletePartNoRequest : IRequest<List<SelectedModel>>
    {
        public string PartNo { get; set; } 
        //public int DepartmentNameId { get; set; } 
    }
}
  