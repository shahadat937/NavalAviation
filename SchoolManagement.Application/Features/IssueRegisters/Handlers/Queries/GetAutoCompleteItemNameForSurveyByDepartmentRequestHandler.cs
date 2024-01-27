using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Queries;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Queries
{
    public class GetAutoCompleteItemNameForSurveyByDepartmentRequestHandler : IRequestHandler<GetAutoCompleteItemNameForSurveyByDepartmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<IssueRegister> _IssueRegisterRepository; 
        public GetAutoCompleteItemNameForSurveyByDepartmentRequestHandler(ISchoolManagementRepository<IssueRegister> IssueRegisterRepository)
        {
            _IssueRegisterRepository = IssueRegisterRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteItemNameForSurveyByDepartmentRequest request, CancellationToken cancellationToken)
        {
          //ICollection<IssueRegister> itemDetails = await _IssueRegisterRepository.FilterAsync((x => x.IsActive && x.ItemDetail.NameOfItem.Contains(request.NameOfItem) && x.DepartmentNameId==request.DepartmentNameId), "ItemDetail");
            var itemDetails =  _IssueRegisterRepository.FilterWithInclude((x => x.IsActive && x.ItemDetail.NameOfItem.Contains(request.NameOfItem) && x.DepartmentNameId == request.DepartmentNameId), "ItemDetail");
            var selectModels = itemDetails.Select(x => new SelectedModel
                { 
                    Text = x.ItemDetail.NameOfItem+"-"+x.ItemDetail.PartNo,
                    Value = x.IssueRegisterId
                }).ToList();
                return selectModels;
            }
      }
}
