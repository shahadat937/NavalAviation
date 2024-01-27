using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.Features.GseItemNames.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Queries
{
    public class GetGseItemNameDetailRequestHandler : IRequestHandler<GetGseItemNameDetailRequest, GseItemNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<GseItemName> _GseItemNameRepository;
        public GetGseItemNameDetailRequestHandler(ISchoolManagementRepository<GseItemName> GseItemNameRepository, IMapper mapper)
        {
            _GseItemNameRepository = GseItemNameRepository;
            _mapper = mapper;
        }
        public async Task<GseItemNameDto> Handle(GetGseItemNameDetailRequest request, CancellationToken cancellationToken)
        {
            var GseItemName = await _GseItemNameRepository.Get(request.GseItemNameId);
            return _mapper.Map<GseItemNameDto>(GseItemName);
        }
    }
}
