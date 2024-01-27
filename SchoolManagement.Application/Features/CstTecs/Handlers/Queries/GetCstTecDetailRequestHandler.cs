using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.Features.CstTecs.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CstTecs.Handlers.Queries
{
    public class GetCstTecDetailRequestHandler : IRequestHandler<GetCstTecDetailRequest, CstTecDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CstTec> _CstTecRepository;
        public GetCstTecDetailRequestHandler(ISchoolManagementRepository<CstTec> CstTecRepository, IMapper mapper)
        {
            _CstTecRepository = CstTecRepository;
            _mapper = mapper;
        }
        public async Task<CstTecDto> Handle(GetCstTecDetailRequest request, CancellationToken cancellationToken)
        {
            var CstTec = await _CstTecRepository.Get(request.CstTecId);
            return _mapper.Map<CstTecDto>(CstTec);
        }
    }
}
