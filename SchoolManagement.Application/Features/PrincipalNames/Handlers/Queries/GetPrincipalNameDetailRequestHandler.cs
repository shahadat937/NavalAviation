using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Queries
{
    public class GetPrincipalNameDetailRequestHandler : IRequestHandler<GetPrincipalNameDetailRequest, PrincipalNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<PrincipalName> _PrincipalNameRepository;
        public GetPrincipalNameDetailRequestHandler(ISchoolManagementRepository<PrincipalName> PrincipalNameRepository, IMapper mapper)
        {
            _PrincipalNameRepository = PrincipalNameRepository;
            _mapper = mapper;
        }
        public async Task<PrincipalNameDto> Handle(GetPrincipalNameDetailRequest request, CancellationToken cancellationToken)
        {
            var PrincipalName = await _PrincipalNameRepository.Get(request.PrincipalNameId);
            return _mapper.Map<PrincipalNameDto>(PrincipalName);
        }
    }
}
