using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Queries
{
    public class GetSelectedMaintenanceTypeRequestHandler : IRequestHandler<GetSelectedMaintenanceTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceType> _MaintenanceTypeRepository;


        public GetSelectedMaintenanceTypeRequestHandler(ISchoolManagementRepository<MaintenanceType> MaintenanceTypeRepository)
        {
            _MaintenanceTypeRepository = MaintenanceTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMaintenanceTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceType> codeValues = await _MaintenanceTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.MaintenanceTypeId
            }).ToList();
            return selectModels;
        }
    }
}
