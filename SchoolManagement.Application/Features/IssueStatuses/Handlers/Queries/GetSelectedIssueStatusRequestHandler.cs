using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.IssueStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Queries
{
    public class GetSelectedIssueStatusRequestHandler : IRequestHandler<GetSelectedIssueStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<IssueStatus> _IssueStatusRepository;


        public GetSelectedIssueStatusRequestHandler(ISchoolManagementRepository<IssueStatus> IssueStatusRepository)
        {
            _IssueStatusRepository = IssueStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedIssueStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<IssueStatus> codeValues = await _IssueStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.IssueStatusId
            }).ToList();
            return selectModels;
        }
    }
}
