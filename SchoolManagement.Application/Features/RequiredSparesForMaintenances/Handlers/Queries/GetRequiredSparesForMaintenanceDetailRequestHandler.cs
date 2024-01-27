using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetRequiredSparesForMaintenanceDetailRequestHandler : IRequestHandler<GetRequiredSparesForMaintenanceDetailRequest, RequiredSparesForMaintenanceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RequiredSparesForMaintenance> _RequiredSparesForMaintenanceRepository;
        public GetRequiredSparesForMaintenanceDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RequiredSparesForMaintenance> RequiredSparesForMaintenanceRepository, IMapper mapper)
        {
            _RequiredSparesForMaintenanceRepository = RequiredSparesForMaintenanceRepository;
            _mapper = mapper;
        }
        public async Task<RequiredSparesForMaintenanceDto> Handle(GetRequiredSparesForMaintenanceDetailRequest request, CancellationToken cancellationToken)
        {
            var RequiredSparesForMaintenance = await _RequiredSparesForMaintenanceRepository.Get(request.RequiredSparesForMaintenanceId);
            return _mapper.Map<RequiredSparesForMaintenanceDto>(RequiredSparesForMaintenance);
        }
    }
}
