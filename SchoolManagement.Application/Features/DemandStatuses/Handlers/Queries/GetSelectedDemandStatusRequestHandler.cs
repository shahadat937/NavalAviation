using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Queries
{
    public class GetSelectedDemandStatusRequestHandler : IRequestHandler<GetSelectedDemandStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandStatus> _DemandStatusRepository;


        public GetSelectedDemandStatusRequestHandler(ISchoolManagementRepository<DemandStatus> DemandStatusRepository)
        {
            _DemandStatusRepository = DemandStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandStatus> codeValues = await _DemandStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DemandStatusId
            }).ToList();
            return selectModels;
        }
    }
}
