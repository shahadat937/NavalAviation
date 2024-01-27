using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Queries
{
    public class GetDemandStatusDetailRequestHandler : IRequestHandler<GetDemandStatusDetailRequest, DemandStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<DemandStatus> _DemandStatusRepository;
        public GetDemandStatusDetailRequestHandler(ISchoolManagementRepository<DemandStatus> DemandStatusRepository, IMapper mapper)
        {
            _DemandStatusRepository = DemandStatusRepository;
            _mapper = mapper;
        }
        public async Task<DemandStatusDto> Handle(GetDemandStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandStatus = await _DemandStatusRepository.Get(request.DemandStatusId);
            return _mapper.Map<DemandStatusDto>(DemandStatus);
        }
    }
}
