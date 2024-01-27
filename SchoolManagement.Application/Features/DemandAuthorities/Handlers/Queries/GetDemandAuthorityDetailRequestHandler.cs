using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandAuthority;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries;

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Queries
{
    public class GetDemandAuthorityDetailRequestHandler : IRequestHandler<GetDemandAuthorityDetailRequest, DemandAuthorityDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandAuthority> _DemandAuthorityRepository;
        public GetDemandAuthorityDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandAuthority> DemandAuthorityRepository, IMapper mapper)
        {
            _DemandAuthorityRepository = DemandAuthorityRepository;
            _mapper = mapper;
        }
        public async Task<DemandAuthorityDto> Handle(GetDemandAuthorityDetailRequest request, CancellationToken cancellationToken)
        {
            var DemandAuthority = await _DemandAuthorityRepository.Get(request.DemandAuthorityId);
            return _mapper.Map<DemandAuthorityDto>(DemandAuthority);
        }
    }
}
