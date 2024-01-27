using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Queries
{
    public class GetGseMaintenanceScheduleNameDetailRequestHandler : IRequestHandler<GetGseMaintenanceScheduleNameDetailRequest, GseMaintenanceScheduleNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<GseMaintenanceScheduleName> _GseMaintenanceScheduleNameRepository;
        public GetGseMaintenanceScheduleNameDetailRequestHandler(ISchoolManagementRepository<GseMaintenanceScheduleName> GseMaintenanceScheduleNameRepository, IMapper mapper)
        {
            _GseMaintenanceScheduleNameRepository = GseMaintenanceScheduleNameRepository;
            _mapper = mapper;
        }
        public async Task<GseMaintenanceScheduleNameDto> Handle(GetGseMaintenanceScheduleNameDetailRequest request, CancellationToken cancellationToken)
        {
            var GseMaintenanceScheduleName = await _GseMaintenanceScheduleNameRepository.Get(request.GseMaintenanceScheduleNameId);
            return _mapper.Map<GseMaintenanceScheduleNameDto>(GseMaintenanceScheduleName);
        }
    }
}
