using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AcStatus;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Queries
{
    public class GetAcStatusDetailRequestHandler : IRequestHandler<GetAcStatusDetailRequest, AcStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AcStatus> _AcStatusRepository;
        public GetAcStatusDetailRequestHandler(ISchoolManagementRepository<AcStatus> AcStatusRepository, IMapper mapper)
        {
            _AcStatusRepository = AcStatusRepository;
            _mapper = mapper;
        }
        public async Task<AcStatusDto> Handle(GetAcStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var AcStatus = await _AcStatusRepository.Get(request.AcStatusId);
            return _mapper.Map<AcStatusDto>(AcStatus);
        }
    }
}
