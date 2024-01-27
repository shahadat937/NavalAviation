using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Queries
{
    public class GetDegitalArchieveDetailRequestHandler : IRequestHandler<GetDegitalArchieveDetailRequest, DegitalArchieveDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieve> _DegitalArchieveRepository;
        public GetDegitalArchieveDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieve> DegitalArchieveRepository, IMapper mapper)
        {
            _DegitalArchieveRepository = DegitalArchieveRepository;
            _mapper = mapper;
        }
        public async Task<DegitalArchieveDto> Handle(GetDegitalArchieveDetailRequest request, CancellationToken cancellationToken)
        {
            var DegitalArchieve = await _DegitalArchieveRepository.Get(request.DegitalArchieveId);
            return _mapper.Map<DegitalArchieveDto>(DegitalArchieve);
        }
    }
}
