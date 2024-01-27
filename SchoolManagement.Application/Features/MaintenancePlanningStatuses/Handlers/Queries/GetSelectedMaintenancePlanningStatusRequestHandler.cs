using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Queries
{
    public class GetSelectedMaintenancePlanningStatusRequestHandler : IRequestHandler<GetSelectedMaintenancePlanningStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenancePlanningStatus> _MaintenancePlanningStatusRepository;


        public GetSelectedMaintenancePlanningStatusRequestHandler(ISchoolManagementRepository<MaintenancePlanningStatus> MaintenancePlanningStatusRepository)
        {
            _MaintenancePlanningStatusRepository = MaintenancePlanningStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenancePlanningStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenancePlanningStatus> codeValues = await _MaintenancePlanningStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.MaintenancePlanningStatusId
            }).ToList();
            return selectModels;
        }
    }
}
