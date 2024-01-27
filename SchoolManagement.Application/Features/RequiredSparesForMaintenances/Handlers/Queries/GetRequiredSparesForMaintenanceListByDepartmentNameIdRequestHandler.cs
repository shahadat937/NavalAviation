using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetRequiredSparesForMaintenanceListByDepartmentNameIdRequestHandler : IRequestHandler<GetRequiredSparesForMaintenanceListByDepartmentNameIdRequest, List<RequiredSparesForMaintenanceDto>>
    {
        private readonly ISchoolManagementRepository<RequiredSparesForMaintenance> _RequiredSparesForMaintenanceRepository;

        private readonly IMapper _mapper;
        public GetRequiredSparesForMaintenanceListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<RequiredSparesForMaintenance> RequiredSparesForMaintenanceRepository, IMapper mapper)
        {
            _RequiredSparesForMaintenanceRepository = RequiredSparesForMaintenanceRepository;
            _mapper = mapper;
        }

        public async Task<List<RequiredSparesForMaintenanceDto>> Handle(GetRequiredSparesForMaintenanceListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<RequiredSparesForMaintenance> RequiredSparesForMaintenances = _RequiredSparesForMaintenanceRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "DepartmentName", "ItemDetail", "MaintenanceType", "MaintenanceCategory", "MaintenanceSubCategory");
            var totalCount = RequiredSparesForMaintenances.Count();
            RequiredSparesForMaintenances = RequiredSparesForMaintenances.OrderByDescending(x => x.RequiredSparesForMaintenanceId);
            var RequiredSparesForMaintenanceDtos = _mapper.Map<List<RequiredSparesForMaintenanceDto>>(RequiredSparesForMaintenances);

            return RequiredSparesForMaintenanceDtos;
        }

    }
}
