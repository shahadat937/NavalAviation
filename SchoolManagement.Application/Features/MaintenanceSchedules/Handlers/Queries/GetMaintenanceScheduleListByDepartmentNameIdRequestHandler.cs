using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetMaintenanceScheduleListByDepartmentNameIdRequestHandler : IRequestHandler<GetMaintenanceScheduleListByDepartmentNameIdRequest, List<MaintenanceScheduleDto>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;

        private readonly IMapper _mapper;
        public GetMaintenanceScheduleListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository, IMapper mapper)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
            _mapper = mapper;
        }

        public async Task<List<MaintenanceScheduleDto>> Handle(GetMaintenanceScheduleListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenanceSchedule> MaintenanceSchedules = _MaintenanceScheduleRepository.FilterWithInclude(x => x.AirCraftNameId == (request.AirCraftNameId != 0 ? request.AirCraftNameId : x.AirCraftNameId) && x.DepartmentNameId == ( request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.InspCompleteStatus == 0 && (x.StartInspDate >= (request.DateFrom !=null ? request.DateFrom : x.StartInspDate) && x.StartInspDate <= (request.DateTo != null ? request.DateTo : x.StartInspDate)), "DepartmentName", "AirCraftName", "MaintenanceType", "MaintenanceCategory", "MaintenancePlanning", "MaintenancePlanningStatus", "MaintenanceSubCategory");

            var MaintenanceScheduleDtos = _mapper.Map<List<MaintenanceScheduleDto>>(MaintenanceSchedules);

            return MaintenanceScheduleDtos;
        }

    }
}
