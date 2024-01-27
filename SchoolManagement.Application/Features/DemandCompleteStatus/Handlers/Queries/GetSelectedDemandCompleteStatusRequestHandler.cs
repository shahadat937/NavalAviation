using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Queries
{
    public class GetSelectedDemandCompleteStatusRequestHandler : IRequestHandler<GetSelectedDemandCompleteStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandCompleteStatus> _DemandCompleteStatusRepository;


        public GetSelectedDemandCompleteStatusRequestHandler(ISchoolManagementRepository<DemandCompleteStatus> DemandCompleteStatusRepository)
        {
            _DemandCompleteStatusRepository = DemandCompleteStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandCompleteStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandCompleteStatus> codeValues = await _DemandCompleteStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DemandCompleteStatusId
            }).ToList();
            return selectModels;
        }
    }
}
