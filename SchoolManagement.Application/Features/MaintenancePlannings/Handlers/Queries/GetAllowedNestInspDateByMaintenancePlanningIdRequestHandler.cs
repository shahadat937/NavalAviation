using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetAllowedNestInspDateByMaintenancePlanningIdRequestHandler : IRequestHandler<GetAllowedNestInspDateByMaintenancePlanningIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;

          
        public GetAllowedNestInspDateByMaintenancePlanningIdRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetAllowedNestInspDateByMaintenancePlanningIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenancePlanning> MaintenancePlannings = await _MaintenancePlanningRepository.FilterAsync(x =>x.MaintenancePlanningId == request.MaintenancePlanningId);
            List<SelectedModel> selectModels = MaintenancePlannings.Select(x => new SelectedModel
            {
                Text = x.NestInspDate, 
                Value = x.MaintenancePlanningId 
            }).ToList();
            return selectModels;
        }
    }
}
