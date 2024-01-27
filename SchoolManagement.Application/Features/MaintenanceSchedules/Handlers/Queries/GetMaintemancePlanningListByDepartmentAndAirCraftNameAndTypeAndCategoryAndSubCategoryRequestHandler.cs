using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
  public class GetMaintemanceScheduleListByParamsRequestHandler : IRequestHandler<GetMaintemanceScheduleListByParamsRequest, List<MaintenanceScheduleDto>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;

        private readonly IMapper _mapper;
        public GetMaintemanceScheduleListByParamsRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository, IMapper mapper)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
            _mapper = mapper;
        }

        public async Task<List<MaintenanceScheduleDto>> Handle(GetMaintemanceScheduleListByParamsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenanceSchedule> MaintenanceSchedules = _MaintenanceScheduleRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId) && x.AirCraftNameId == (request.AirCraftNameId != 0 ? request.AirCraftNameId : x.AirCraftNameId) && x.MaintenanceTypeId==(request.MaintenanceTypeId != 0 ? request.MaintenanceTypeId : x.MaintenanceTypeId) && x.MaintenanceCategoryId == (request.MaintenanceCategoryId != 0 ? request.MaintenanceCategoryId : x.MaintenanceCategoryId) && x.MaintenanceSubCategoryId == (request.MaintenanceSubCategoryId != 0 ? request.MaintenanceSubCategoryId : x.MaintenanceSubCategoryId));

            var MaintenanceScheduleDtos = _mapper.Map<List<MaintenanceScheduleDto>>(MaintenanceSchedules);

            return MaintenanceScheduleDtos;
        }

    }
}
