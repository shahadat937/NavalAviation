using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Queries
{
    public class GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequestHandler : IRequestHandler<GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceCategory> _MaintenanceCategoryRepository;

          
        public GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequestHandler(ISchoolManagementRepository<MaintenanceCategory> MaintenanceCategoryRepository)
        {
            _MaintenanceCategoryRepository = MaintenanceCategoryRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetMaintenanceCategoryByDepartmentNameIdAndMaintenanceTypeIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceCategory> MaintenanceCategorys = await _MaintenanceCategoryRepository.FilterAsync(x => x.DepartmentNameId == request.DepartmentNameId && x.MaintenanceTypeId==request.MaintenanceTypeId);
            List<SelectedModel> selectModels = MaintenanceCategorys.Select(x => new SelectedModel
            {
                Text = x.CategoryName, 
                Value = x.MaintenanceCategoryId 
            }).ToList();
            return selectModels;
        }
    }
}
