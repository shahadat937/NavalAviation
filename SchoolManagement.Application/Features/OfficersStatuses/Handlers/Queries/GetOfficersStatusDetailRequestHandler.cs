using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Queries
{
    public class GetOfficersStatusDetailRequestHandler : IRequestHandler<GetOfficersStatusDetailRequest, OfficersStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OfficersStatus> _OfficersStatusRepository;
        public GetOfficersStatusDetailRequestHandler(ISchoolManagementRepository<OfficersStatus> OfficersStatusRepository, IMapper mapper)
        {
            _OfficersStatusRepository = OfficersStatusRepository;
            _mapper = mapper;
        }
        public async Task<OfficersStatusDto> Handle(GetOfficersStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var OfficersStatus = await _OfficersStatusRepository.Get(request.OfficersStatusId);
            return _mapper.Map<OfficersStatusDto>(OfficersStatus);
        }
    }
}
