using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetMaintenancePlanningDetailRequestHandler : IRequestHandler<GetMaintenancePlanningDetailRequest, MaintenancePlanningDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;
        public GetMaintenancePlanningDetailRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository, IMapper mapper)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
            _mapper = mapper;
        }
        public async Task<MaintenancePlanningDto> Handle(GetMaintenancePlanningDetailRequest request, CancellationToken cancellationToken)
        {
      //var MaintenancePlanning = await _MaintenancePlanningRepository.Get(request.MaintenancePlanningId);
      //return _mapper.Map<MaintenancePlanningDto>(MaintenancePlanning);
      var MaintenancePlanning = _MaintenancePlanningRepository.FinedOneInclude(x => x.MaintenancePlanningId == request.MaintenancePlanningId, "DepartmentName", "AirCraftName", "MaintenanceType", "MaintenanceCategory", "MaintenanceSubCategory");
      return _mapper.Map<MaintenancePlanningDto>(MaintenancePlanning);
    }
    }
}
