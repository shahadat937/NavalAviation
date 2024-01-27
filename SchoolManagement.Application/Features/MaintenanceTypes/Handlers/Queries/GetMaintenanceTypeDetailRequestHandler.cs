using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Queries
{
    public class GetMaintenanceTypeDetailRequestHandler : IRequestHandler<GetMaintenanceTypeDetailRequest, MaintenanceTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenanceType> _MaintenanceTypeRepository;
        public GetMaintenanceTypeDetailRequestHandler(ISchoolManagementRepository<MaintenanceType> MaintenanceTypeRepository, IMapper mapper)
        {
            _MaintenanceTypeRepository = MaintenanceTypeRepository;
            _mapper = mapper;
        }
        public async Task<MaintenanceTypeDto> Handle(GetMaintenanceTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenanceType = await _MaintenanceTypeRepository.Get(request.MaintenanceTypeId);
            return _mapper.Map<MaintenanceTypeDto>(MaintenanceType);
        }
    }
}
