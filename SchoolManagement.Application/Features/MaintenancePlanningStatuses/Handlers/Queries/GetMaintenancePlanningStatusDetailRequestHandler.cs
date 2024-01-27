using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Queries
{
    public class GetMaintenancePlanningStatusDetailRequestHandler : IRequestHandler<GetMaintenancePlanningStatusDetailRequest, MaintenancePlanningStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenancePlanningStatus> _MaintenancePlanningStatusRepository;
        public GetMaintenancePlanningStatusDetailRequestHandler(ISchoolManagementRepository<MaintenancePlanningStatus> MaintenancePlanningStatusRepository, IMapper mapper)
        {
            _MaintenancePlanningStatusRepository = MaintenancePlanningStatusRepository;
            _mapper = mapper;
        }
        public async Task<MaintenancePlanningStatusDto> Handle(GetMaintenancePlanningStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenancePlanningStatus = await _MaintenancePlanningStatusRepository.Get(request.MaintenancePlanningStatusId);
            return _mapper.Map<MaintenancePlanningStatusDto>(MaintenancePlanningStatus);
        }
    }
}
