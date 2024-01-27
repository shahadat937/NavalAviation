using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Queries
{
    public class GetSelectedMaintenanceCategoryByDepartmentRequestHandler : IRequestHandler<GetSelectedMaintenanceCategoryByDepartmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceCategory> _MaintenanceCategoryRepository;


        public GetSelectedMaintenanceCategoryByDepartmentRequestHandler(ISchoolManagementRepository<MaintenanceCategory> MaintenanceCategoryRepository)
        {
            _MaintenanceCategoryRepository = MaintenanceCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceCategoryByDepartmentRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceCategory> codeValues = await _MaintenanceCategoryRepository.FilterAsync(x => x.IsActive && x.DepartmentNameId ==request.DepartmentNameId);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CategoryName,
                Value = x.MaintenanceCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
