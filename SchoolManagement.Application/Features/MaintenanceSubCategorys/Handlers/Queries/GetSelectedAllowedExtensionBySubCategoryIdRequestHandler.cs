using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetSelectedAllowedExtensionBySubCategoryIdRequestHandler : IRequestHandler<GetSelectedAllowedExtensionBySubCategoryIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;

          
        public GetSelectedAllowedExtensionBySubCategoryIdRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAllowedExtensionBySubCategoryIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceSubCategory> MaintenanceSubCategorys = await _MaintenanceSubCategoryRepository.FilterAsync(x =>x.MaintenanceSubCategoryId == request.MaintenanceSubCategoryId);
            List<SelectedModel> selectModels = MaintenanceSubCategorys.Select(x => new SelectedModel
            {
                Text = x.AllowedExtension, 
                Value = x.MaintenanceSubCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
