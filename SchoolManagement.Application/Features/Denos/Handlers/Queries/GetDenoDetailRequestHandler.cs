using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Denos;
using SchoolManagement.Application.Features.Denos.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Denos.Handlers.Queries
{
    public class GetDenoDetailRequestHandler : IRequestHandler<GetDenoDetailRequest, DenoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Deno> _DenoRepository;
        public GetDenoDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Deno> DenoRepository, IMapper mapper)
        {
            _DenoRepository = DenoRepository;
            _mapper = mapper;
        }
        public async Task<DenoDto> Handle(GetDenoDetailRequest request, CancellationToken cancellationToken)
        {
            var Deno = await _DenoRepository.Get(request.DenoId);
            return _mapper.Map<DenoDto>(Deno);
        }
    }
}
