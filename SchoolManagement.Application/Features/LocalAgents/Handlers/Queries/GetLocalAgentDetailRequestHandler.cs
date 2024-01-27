using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.Features.LocalAgents.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Queries
{
    public class GetLocalAgentDetailRequestHandler : IRequestHandler<GetLocalAgentDetailRequest, LocalAgentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<LocalAgent> _LocalAgentRepository;
        public GetLocalAgentDetailRequestHandler(ISchoolManagementRepository<LocalAgent> LocalAgentRepository, IMapper mapper)
        {
            _LocalAgentRepository = LocalAgentRepository;
            _mapper = mapper;
        }
        public async Task<LocalAgentDto> Handle(GetLocalAgentDetailRequest request, CancellationToken cancellationToken)
        {
            var LocalAgent = await _LocalAgentRepository.Get(request.LocalAgentId);
            return _mapper.Map<LocalAgentDto>(LocalAgent);
        }
    }
}
