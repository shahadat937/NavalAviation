using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.Features.Statuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Statuses.Handlers.Queries
{
    public class GetStatusDetailRequestHandler : IRequestHandler<GetStatusDetailRequest, StatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Status> _StatusRepository;
        public GetStatusDetailRequestHandler(ISchoolManagementRepository<Status> StatusRepository, IMapper mapper)
        {
            _StatusRepository = StatusRepository;
            _mapper = mapper;
        }
        public async Task<StatusDto> Handle(GetStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var Status = await _StatusRepository.Get(request.StatusId);
            return _mapper.Map<StatusDto>(Status);
        }
    }
}
