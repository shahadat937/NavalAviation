using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PresentState;
using SchoolManagement.Application.Features.PresentStates.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PresentStates.Handlers.Queries
{
    public class GetPresentStateDetailRequestHandler : IRequestHandler<GetPresentStateDetailRequest, PresentStateDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PresentState> _PresentStateRepository;
        public GetPresentStateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PresentState> PresentStateRepository, IMapper mapper)
        {
            _PresentStateRepository = PresentStateRepository;
            _mapper = mapper;
        }
        public async Task<PresentStateDto> Handle(GetPresentStateDetailRequest request, CancellationToken cancellationToken)
        {
            var PresentState = await _PresentStateRepository.Get(request.PresentStateId);
            return _mapper.Map<PresentStateDto>(PresentState);
        }
    }
}
