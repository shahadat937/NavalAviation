using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DepartmentNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Queries
{
    public class GetSelectedDepartmentNameRequestHandler : IRequestHandler<GetSelectedDepartmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DepartmentName> _DepartmentNameRepository;


        public GetSelectedDepartmentNameRequestHandler(ISchoolManagementRepository<DepartmentName> DepartmentNameRepository)
        {
            _DepartmentNameRepository = DepartmentNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDepartmentNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<DepartmentName> codeValues = await _DepartmentNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DepartmentNameId
            }).ToList();
            return selectModels;
        }
    }
}
