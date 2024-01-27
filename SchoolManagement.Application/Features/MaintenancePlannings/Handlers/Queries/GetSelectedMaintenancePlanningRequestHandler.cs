using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetSelectedMaintenancePlanningRequestHandler : IRequestHandler<GetSelectedMaintenancePlanningRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;


        public GetSelectedMaintenancePlanningRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenancePlanningRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenancePlanning> MaintenancePlannings = _MaintenancePlanningRepository.FilterWithInclude(x => x.IsActive, "MaintenanceSubCategory");
            List<SelectedModel> selectModels = MaintenancePlannings.Select(x => new SelectedModel
            {
                Text = x.MaintenanceSubCategory.SubCategoryName,
                Value = x.MaintenancePlanningId
            }).ToList();
            return selectModels;
        }
    }
}
