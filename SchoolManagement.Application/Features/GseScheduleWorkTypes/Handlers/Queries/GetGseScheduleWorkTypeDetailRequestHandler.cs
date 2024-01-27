using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Queries
{
    public class GetGseScheduleWorkTypeDetailRequestHandler : IRequestHandler<GetGseScheduleWorkTypeDetailRequest, GseScheduleWorkTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<GseScheduleWorkType> _GseScheduleWorkTypeRepository;
        public GetGseScheduleWorkTypeDetailRequestHandler(ISchoolManagementRepository<GseScheduleWorkType> GseScheduleWorkTypeRepository, IMapper mapper)
        {
            _GseScheduleWorkTypeRepository = GseScheduleWorkTypeRepository;
            _mapper = mapper;
        }
        public async Task<GseScheduleWorkTypeDto> Handle(GetGseScheduleWorkTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var GseScheduleWorkType = await _GseScheduleWorkTypeRepository.Get(request.GseScheduleWorkTypeId);
            return _mapper.Map<GseScheduleWorkTypeDto>(GseScheduleWorkType);
        }
    }
}
