using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CallibrationState;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CallibrationStates.Handlers.Queries
{
    public class GetCallibrationStateDetailRequestHandler : IRequestHandler<GetCallibrationStateDetailRequest, CallibrationStateDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CallibrationState> _CallibrationStateRepository;
        public GetCallibrationStateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CallibrationState> CallibrationStateRepository, IMapper mapper)
        {
            _CallibrationStateRepository = CallibrationStateRepository;
            _mapper = mapper;
        }
        public async Task<CallibrationStateDto> Handle(GetCallibrationStateDetailRequest request, CancellationToken cancellationToken)
        {
            var CallibrationState = await _CallibrationStateRepository.Get(request.CallibrationStateId);
            return _mapper.Map<CallibrationStateDto>(CallibrationState);
        }
    }
}
