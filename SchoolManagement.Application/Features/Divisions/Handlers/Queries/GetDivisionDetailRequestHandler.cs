using AutoMapper;
using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.Features.Divisions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Handlers.Queries
{
    public class GetDivisionDetailRequestHandler : IRequestHandler<GetDivisionDetailRequest, DivisionDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Division> _DivisionRepository;
        public GetDivisionDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Division> DivisionRepository, IMapper mapper)
        {
            _DivisionRepository = DivisionRepository;
            _mapper = mapper;
        }
        public async Task<DivisionDto> Handle(GetDivisionDetailRequest request, CancellationToken cancellationToken)
        {
            var Division = await _DivisionRepository.Get(request.DivisionId);
            return _mapper.Map<DivisionDto>(Division);
        }
    }
}
