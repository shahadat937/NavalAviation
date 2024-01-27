using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.Features.GseMaintenances.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenances.Handlers.Queries
{
    public class GetGseMaintenanceDetailRequestHandler : IRequestHandler<GetGseMaintenanceDetailRequest, GseMaintenanceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<GseMaintenance> _GseMaintenanceRepository;
        public GetGseMaintenanceDetailRequestHandler(ISchoolManagementRepository<GseMaintenance> GseMaintenanceRepository, IMapper mapper)
        {
            _GseMaintenanceRepository = GseMaintenanceRepository;
            _mapper = mapper;
        }
        public async Task<GseMaintenanceDto> Handle(GetGseMaintenanceDetailRequest request, CancellationToken cancellationToken)
        {
            var GseMaintenance = await _GseMaintenanceRepository.Get(request.GseMaintenanceId);
            return _mapper.Map<GseMaintenanceDto>(GseMaintenance);
        }
    }
}
