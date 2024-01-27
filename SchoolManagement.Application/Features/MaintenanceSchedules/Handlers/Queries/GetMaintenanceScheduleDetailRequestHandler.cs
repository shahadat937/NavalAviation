using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetMaintenanceScheduleDetailRequestHandler : IRequestHandler<GetMaintenanceScheduleDetailRequest, MaintenanceScheduleDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;
        public GetMaintenanceScheduleDetailRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository, IMapper mapper)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
            _mapper = mapper;
        }
        public async Task<MaintenanceScheduleDto> Handle(GetMaintenanceScheduleDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenanceSchedule = await _MaintenanceScheduleRepository.Get(request.MaintenanceScheduleId);
            return _mapper.Map<MaintenanceScheduleDto>(MaintenanceSchedule);
        }
    }
}
