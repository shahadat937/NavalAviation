using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetSelectedRequiredSparesForMaintenanceRequestHandler : IRequestHandler<GetSelectedRequiredSparesForMaintenanceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<RequiredSparesForMaintenance> _RequiredSparesForMaintenanceRepository;


        public GetSelectedRequiredSparesForMaintenanceRequestHandler(ISchoolManagementRepository<RequiredSparesForMaintenance> RequiredSparesForMaintenanceRepository)
        {
            _RequiredSparesForMaintenanceRepository = RequiredSparesForMaintenanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRequiredSparesForMaintenanceRequest request, CancellationToken cancellationToken)
        {
            ICollection<RequiredSparesForMaintenance> codeValues = await _RequiredSparesForMaintenanceRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemDetail.NameOfItem,
                Value = x.RequiredSparesForMaintenanceId
            }).ToList();
            return selectModels;
        }
    }
}
