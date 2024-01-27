using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.Features.Authoritys.Requests.Queries;

namespace SchoolManagement.Application.Features.Authoritys.Handlers.Queries
{
    public class GetAuthorityDetailRequestHandler : IRequestHandler<GetAuthorityDetailRequest, AuthorityDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Authority> _AuthorityRepository;
        public GetAuthorityDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Authority> AuthorityRepository, IMapper mapper)
        {
            _AuthorityRepository = AuthorityRepository;
            _mapper = mapper;
        }
        public async Task<AuthorityDto> Handle(GetAuthorityDetailRequest request, CancellationToken cancellationToken)
        {
            var Authority = await _AuthorityRepository.Get(request.AuthorityId);
            return _mapper.Map<AuthorityDto>(Authority);
        }
    }
}
