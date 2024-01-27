using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Queries
{
    public class GetSelectedMaintenanceCategoryRequestHandler : IRequestHandler<GetSelectedMaintenanceCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceCategory> _MaintenanceCategoryRepository;


        public GetSelectedMaintenanceCategoryRequestHandler(ISchoolManagementRepository<MaintenanceCategory> MaintenanceCategoryRepository)
        {
            _MaintenanceCategoryRepository = MaintenanceCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceCategory> codeValues = await _MaintenanceCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CategoryName,
                Value = x.MaintenanceCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
