using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetSelectedMaintenanceScheduleRequestHandler : IRequestHandler<GetSelectedMaintenanceScheduleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;


        public GetSelectedMaintenanceScheduleRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceScheduleRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceSchedule> codeValues = await _MaintenanceScheduleRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SlNo,
                Value = x.MaintenanceScheduleId
            }).ToList();
            return selectModels;
        }
    }
}
