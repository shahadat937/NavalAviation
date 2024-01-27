using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandDocs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Queries
{
    public class GetSelectedDemandDocRequestHandler : IRequestHandler<GetSelectedDemandDocRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandDoc> _DemandDocRepository;


        public GetSelectedDemandDocRequestHandler(ISchoolManagementRepository<DemandDoc> DemandDocRepository)
        {
            _DemandDocRepository = DemandDocRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandDocRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandDoc> codeValues = await _DemandDocRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DemandDocId
            }).ToList();
            return selectModels;
        }
    }
}
