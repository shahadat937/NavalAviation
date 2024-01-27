using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MaintenenceStates.Handlers.Queries
{
    public class GetMaintenenceStateDetailRequestHandler : IRequestHandler<GetMaintenenceStateDetailRequest, MaintenenceStateDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MaintenenceState> _MaintenenceStateRepository;
        public GetMaintenenceStateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MaintenenceState> MaintenenceStateRepository, IMapper mapper)
        {
            _MaintenenceStateRepository = MaintenenceStateRepository;
            _mapper = mapper;
        }
        public async Task<MaintenenceStateDto> Handle(GetMaintenenceStateDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenenceState = await _MaintenenceStateRepository.Get(request.MaintenenceStateId);
            return _mapper.Map<MaintenenceStateDto>(MaintenenceState);
        }
    }
}
