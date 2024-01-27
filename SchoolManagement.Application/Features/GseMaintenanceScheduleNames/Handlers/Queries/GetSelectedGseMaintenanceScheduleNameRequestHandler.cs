using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Queries
{
    public class GetSelectedGseMaintenanceScheduleNameRequestHandler : IRequestHandler<GetSelectedGseMaintenanceScheduleNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GseMaintenanceScheduleName> _GseMaintenanceScheduleNameRepository;


        public GetSelectedGseMaintenanceScheduleNameRequestHandler(ISchoolManagementRepository<GseMaintenanceScheduleName> GseMaintenanceScheduleNameRepository)
        {
            _GseMaintenanceScheduleNameRepository = GseMaintenanceScheduleNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGseMaintenanceScheduleNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<GseMaintenanceScheduleName> codeValues = await _GseMaintenanceScheduleNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ScheduleName,
                Value = x.GseMaintenanceScheduleNameId
            }).ToList();
            return selectModels;
        }
    }
}
