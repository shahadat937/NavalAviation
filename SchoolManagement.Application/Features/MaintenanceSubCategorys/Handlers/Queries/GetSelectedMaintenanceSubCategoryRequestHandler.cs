using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetSelectedMaintenanceSubCategoryRequestHandler : IRequestHandler<GetSelectedMaintenanceSubCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;


        public GetSelectedMaintenanceSubCategoryRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceSubCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceSubCategory> codeValues = await _MaintenanceSubCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SubCategoryName,
                Value = x.MaintenanceSubCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
