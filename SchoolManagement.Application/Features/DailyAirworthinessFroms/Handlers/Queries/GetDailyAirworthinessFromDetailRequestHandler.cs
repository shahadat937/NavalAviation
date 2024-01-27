using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Queries
{
    public class GetDailyAirworthinessFromDetailRequestHandler : IRequestHandler<GetDailyAirworthinessFromDetailRequest, DailyAirworthinessFromDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFrom> _DailyAirworthinessFromRepository;
        public GetDailyAirworthinessFromDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFrom> DailyAirworthinessFromRepository, IMapper mapper)
        {
            _DailyAirworthinessFromRepository = DailyAirworthinessFromRepository;
            _mapper = mapper;
        }
        public async Task<DailyAirworthinessFromDto> Handle(GetDailyAirworthinessFromDetailRequest request, CancellationToken cancellationToken)
        {
            var DailyAirworthinessFrom = await _DailyAirworthinessFromRepository.Get(request.DailyAirworthinessFromId);
            return _mapper.Map<DailyAirworthinessFromDto>(DailyAirworthinessFrom);
        }
    }
}
