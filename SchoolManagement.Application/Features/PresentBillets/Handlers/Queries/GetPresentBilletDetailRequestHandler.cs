using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PresentBillets;
using SchoolManagement.Application.Features.PresentBillets.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PresentBillets.Handlers.Queries
{
    public class GetPresentBilletDetailRequestHandler : IRequestHandler<GetPresentBilletDetailRequest, PresentBilletDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PresentBillet> _PresentBilletRepository;
        public GetPresentBilletDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PresentBillet> PresentBilletRepository, IMapper mapper)
        {
            _PresentBilletRepository = PresentBilletRepository;
            _mapper = mapper;
        }
        public async Task<PresentBilletDto> Handle(GetPresentBilletDetailRequest request, CancellationToken cancellationToken)
        {
            var PresentBillet = await _PresentBilletRepository.Get(request.PresentBilletId);
            return _mapper.Map<PresentBilletDto>(PresentBillet);
        }
    }
}
