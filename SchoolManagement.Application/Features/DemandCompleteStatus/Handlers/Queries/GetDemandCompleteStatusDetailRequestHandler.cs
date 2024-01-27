using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Queries
{
    public class GetDemandCompleteStatusDetailRequestHandler : IRequestHandler<GetDemandCompleteStatusDetailRequest, DemandCompleteStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<DemandCompleteStatus> _DemandCompleteStatusRepository;
        public GetDemandCompleteStatusDetailRequestHandler(ISchoolManagementRepository<DemandCompleteStatus> DemandCompleteStatusRepository, IMapper mapper)
        {
            _DemandCompleteStatusRepository = DemandCompleteStatusRepository;
            _mapper = mapper;
        }
        public async Task<DemandCompleteStatusDto> Handle(GetDemandCompleteStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandCompleteStatus = await _DemandCompleteStatusRepository.Get(request.DemandCompleteStatusId);
            return _mapper.Map<DemandCompleteStatusDto>(DemandCompleteStatus);
        }
    }
}
