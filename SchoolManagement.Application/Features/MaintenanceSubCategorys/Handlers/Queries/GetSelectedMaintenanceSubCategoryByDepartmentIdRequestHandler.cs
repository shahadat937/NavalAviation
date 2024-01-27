using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetSelectedMaintenanceSubCategoryByDepartmentIdRequestHandler : IRequestHandler<GetSelectedMaintenanceSubCategoryByDepartmentIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;


        public GetSelectedMaintenanceSubCategoryByDepartmentIdRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceSubCategoryByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceSubCategory> codeValues = await _MaintenanceSubCategoryRepository.FilterAsync(x => x.DepartmentNameId==request.DepartmentNameId);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SubCategoryName,
                Value = x.MaintenanceSubCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
