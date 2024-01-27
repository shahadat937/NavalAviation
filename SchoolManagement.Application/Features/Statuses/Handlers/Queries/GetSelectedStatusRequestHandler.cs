using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Statuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Statuses.Handlers.Queries
{
    public class GetSelectedStatusRequestHandler : IRequestHandler<GetSelectedStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Status> _StatusRepository;


        public GetSelectedStatusRequestHandler(ISchoolManagementRepository<Status> StatusRepository)
        {
            _StatusRepository = StatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<Status> codeValues = await _StatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.StatusId
            }).ToList();
            return selectModels;
        }
    }
}
