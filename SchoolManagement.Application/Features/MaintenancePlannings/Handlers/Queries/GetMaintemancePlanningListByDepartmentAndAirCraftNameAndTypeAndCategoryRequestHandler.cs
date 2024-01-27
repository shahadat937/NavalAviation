using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryRequestHandler : IRequestHandler<GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryRequest, List<MaintenancePlanningDto>>
    {
        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;

        private readonly IMapper _mapper;
        public GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository, IMapper mapper)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
            _mapper = mapper;
        }

        public async Task<List<MaintenancePlanningDto>> Handle(GetMaintemancePlanningListByDepartmentAndAirCraftNameAndTypeAndCategoryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenancePlanning> MaintenancePlannings = _MaintenancePlanningRepository.FilterWithInclude(x => x.AirCraftNameId == request.AirCraftNameId && x.DepartmentNameId == request.DepartmentNameId && x.MaintenanceTypeId==request.MaintenanceTypeId && x.MaintenanceCategoryId == request.MaintenanceCategoryId, "DepartmentName", "AirCraftName", "MaintenanceType", "MaintenanceCategory", "MaintenanceSubCategory", "MaintenancePlanningStatus");

            var MaintenancePlanningDtos = _mapper.Map<List<MaintenancePlanningDto>>(MaintenancePlannings);

            return MaintenancePlanningDtos;
        }

    }
}
