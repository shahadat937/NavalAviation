using AutoMapper;
using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.Features.Thanas.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Thanas.Handlers.Queries
{
    public class GetThanaDetailRequestHandler : IRequestHandler<GetThanaDetailRequest, ThanaDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Thana> _ThanaRepository;
        public GetThanaDetailRequestHandler(ISchoolManagementRepository<Thana> ThanaRepository, IMapper mapper)
        {
            _ThanaRepository = ThanaRepository;
            _mapper = mapper;
        }
        public async Task<ThanaDto> Handle(GetThanaDetailRequest request, CancellationToken cancellationToken)
        {
            var Thana = await _ThanaRepository.Get(request.ThanaId);
            return _mapper.Map<ThanaDto>(Thana);
        }
    }
}
