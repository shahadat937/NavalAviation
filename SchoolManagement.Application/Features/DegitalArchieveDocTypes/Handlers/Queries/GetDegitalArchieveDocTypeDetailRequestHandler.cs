using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Queries
{
    public class GetDegitalArchieveDocTypeDetailRequestHandler : IRequestHandler<GetDegitalArchieveDocTypeDetailRequest, DegitalArchieveDocTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieveDocType> _DegitalArchieveDocTypeRepository;
        public GetDegitalArchieveDocTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieveDocType> DegitalArchieveDocTypeRepository, IMapper mapper)
        {
            _DegitalArchieveDocTypeRepository = DegitalArchieveDocTypeRepository;
            _mapper = mapper;
        }
        public async Task<DegitalArchieveDocTypeDto> Handle(GetDegitalArchieveDocTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var DegitalArchieveDocType = await _DegitalArchieveDocTypeRepository.Get(request.DegitalArchieveDocTypeId);
            return _mapper.Map<DegitalArchieveDocTypeDto>(DegitalArchieveDocType);
        }
    }
}
