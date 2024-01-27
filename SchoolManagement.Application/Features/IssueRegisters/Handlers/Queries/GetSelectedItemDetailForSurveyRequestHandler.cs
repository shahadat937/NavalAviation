using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Queries
{
    public class GetSelectedItemDetailForSurveyRequestHandler : IRequestHandler<GetSelectedItemDetailForSurveyRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<IssueRegister> _IssueRegisterRepository;


        public GetSelectedItemDetailForSurveyRequestHandler(ISchoolManagementRepository<IssueRegister> IssueRegisterRepository)
        {
            _IssueRegisterRepository = IssueRegisterRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemDetailForSurveyRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _IssueRegisterRepository.FilterWithInclude(x => x.IsActive, "ItemDetail").Where(x=>x.DepartmentNameId==request.DepartmentNameId);
            var selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemDetail.NameOfItem+'-'+x.ItemDetail.PartNo,
                Value = x.IssueRegisterId
            }).Distinct();
            return selectModels.ToList();
        }
    }
}
