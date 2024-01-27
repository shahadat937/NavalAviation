using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.Features.RunningHours.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Queries
{
    public class GetRunningHourDetailRequestHandler : IRequestHandler<GetRunningHourDetailRequest, RunningHourDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<RunningHour> _RunningHourRepository;
        public GetRunningHourDetailRequestHandler(ISchoolManagementRepository<RunningHour> RunningHourRepository, IMapper mapper)
        {
            _RunningHourRepository = RunningHourRepository;
            _mapper = mapper;
        }
        public async Task<RunningHourDto> Handle(GetRunningHourDetailRequest request, CancellationToken cancellationToken)
        {
            var RunningHour = await _RunningHourRepository.Get(request.RunningHourId);
            return _mapper.Map<RunningHourDto>(RunningHour);
        }
    }
}
