using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Queries
{
    public class GetSourceOfSupplyDetailRequestHandler : IRequestHandler<GetSourceOfSupplyDetailRequest, SourceOfSupplyDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SourceOfSupply> _SourceOfSupplyRepository;
        public GetSourceOfSupplyDetailRequestHandler(ISchoolManagementRepository<SourceOfSupply> SourceOfSupplyRepository, IMapper mapper)
        {
            _SourceOfSupplyRepository = SourceOfSupplyRepository;
            _mapper = mapper;
        }
        public async Task<SourceOfSupplyDto> Handle(GetSourceOfSupplyDetailRequest request, CancellationToken cancellationToken)
        {
            var SourceOfSupply = await _SourceOfSupplyRepository.Get(request.SourceOfSupplyId);
            return _mapper.Map<SourceOfSupplyDto>(SourceOfSupply);
        }
    }
}
