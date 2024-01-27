using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Queries
{
    public class GetMeaSquadronStateDetailRequestHandler : IRequestHandler<GetMeaSquadronStateDetailRequest, MeaSquadronStateDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaSquadronState> _MeaSquadronStateRepository;
        public GetMeaSquadronStateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaSquadronState> MeaSquadronStateRepository, IMapper mapper)
        {
            _MeaSquadronStateRepository = MeaSquadronStateRepository;
            _mapper = mapper;
        }
        public async Task<MeaSquadronStateDto> Handle(GetMeaSquadronStateDetailRequest request, CancellationToken cancellationToken)
        {
            //var MeaSquadronState = await _MeaSquadronStateRepository.Get(request.MeaSquadronStateId);
            //return _mapper.Map<MeaSquadronStateDto>(MeaSquadronState);
            var MeaSquadronState = _MeaSquadronStateRepository.FinedOneInclude(x => x.MeaSquadronStateId == request.MeaSquadronStateId, "DepartmentName", "ItemDetail", "Trade", "ConditionOfItem", "MeaWorkShop");
            return _mapper.Map<MeaSquadronStateDto>(MeaSquadronState);
        }
    }
}
