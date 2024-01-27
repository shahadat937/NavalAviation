using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetAcceptanceDetailRequestHandler : IRequestHandler<GetAcceptanceDetailRequest, AcceptanceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;
        public GetAcceptanceDetailRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository, IMapper mapper)
        {
            _AcceptanceRepository = AcceptanceRepository;
            _mapper = mapper;
        }
        public async Task<AcceptanceDto> Handle(GetAcceptanceDetailRequest request, CancellationToken cancellationToken)
        {
            //var Acceptance = await _AcceptanceRepository.Get(request.AcceptanceId);
            //return _mapper.Map<AcceptanceDto>(Acceptance);
            var Acceptance = _AcceptanceRepository.FinedOneInclude(x => x.AcceptanceId == request.AcceptanceId, "DepartmentName","ItemDetail", "ConditionOfItem", "DemandType");
            return _mapper.Map<AcceptanceDto>(Acceptance);
        }
    }
}
