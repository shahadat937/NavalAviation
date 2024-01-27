using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Queries;

namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Queries
{
    public class GetIssueStatusDetailRequestHandler : IRequestHandler<GetIssueStatusDetailRequest, IssueStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.IssueStatus> _IssueStatusRepository;
        public GetIssueStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.IssueStatus> IssueStatusRepository, IMapper mapper)
        {
            _IssueStatusRepository = IssueStatusRepository;
            _mapper = mapper;
        }
        public async Task<IssueStatusDto> Handle(GetIssueStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var IssueStatus = await _IssueStatusRepository.Get(request.IssueStatusId);
            return _mapper.Map<IssueStatusDto>(IssueStatus);
        }
    }
}
