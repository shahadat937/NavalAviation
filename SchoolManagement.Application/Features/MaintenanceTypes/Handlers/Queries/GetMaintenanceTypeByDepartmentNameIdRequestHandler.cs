using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Queries
{
    public class GetMaintenanceTypeByDepartmentNameIdRequestHandler : IRequestHandler<GetMaintenanceTypeByDepartmentNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MaintenanceType> _MaintenanceTypeRepository;

          
        public GetMaintenanceTypeByDepartmentNameIdRequestHandler(ISchoolManagementRepository<MaintenanceType> MaintenanceTypeRepository)
        {
            _MaintenanceTypeRepository = MaintenanceTypeRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetMaintenanceTypeByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<MaintenanceType> MaintenanceTypes = await _MaintenanceTypeRepository.FilterAsync(x =>x.DepartmentNameId == request.DepartmentNameId);
            List<SelectedModel> selectModels = MaintenanceTypes.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.MaintenanceTypeId 
            }).ToList();
            return selectModels;
        }
    }
}
