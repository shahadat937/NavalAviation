using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequestHandler : IRequestHandler<GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;

          
        public GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetMaintenanceSubCategoryByDepartmentNameIdAndMaintenanceCategoryIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceSubCategory> MaintenanceSubCategorys = await _MaintenanceSubCategoryRepository.FilterAsync(x =>x.MaintenanceCategoryId==request.MaintenanceCategoryId);
            List<SelectedModel> selectModels = MaintenanceSubCategorys.Select(x => new SelectedModel
            {
                Text = x.SubCategoryName, 
                Value = x.MaintenanceSubCategoryId 
            }).ToList();
            return selectModels;
        }
    }
}
