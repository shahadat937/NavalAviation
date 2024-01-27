using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Queries
{
    public class GetLifeLimitItemRunningHourDetailRequestHandler : IRequestHandler<GetLifeLimitItemRunningHourDetailRequest, LifeLimitItemRunningHourDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<LifeLimitItemRunningHour> _LifeLimitItemRunningHourRepository;
        public GetLifeLimitItemRunningHourDetailRequestHandler(ISchoolManagementRepository<LifeLimitItemRunningHour> LifeLimitItemRunningHourRepository, IMapper mapper)
        {
            _LifeLimitItemRunningHourRepository = LifeLimitItemRunningHourRepository;
            _mapper = mapper;
        }
        public async Task<LifeLimitItemRunningHourDto> Handle(GetLifeLimitItemRunningHourDetailRequest request, CancellationToken cancellationToken)
        {
            var LifeLimitItemRunningHour = await _LifeLimitItemRunningHourRepository.Get(request.LifeLimitItemRunningHourId);
            return _mapper.Map<LifeLimitItemRunningHourDto>(LifeLimitItemRunningHour);
        }
    }
}
