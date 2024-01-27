using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SailorRanks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Queries
{
    public class GetSelectedSailorRankRequestHandler : IRequestHandler<GetSelectedSailorRankRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SailorRank> _SailorRankRepository;


        public GetSelectedSailorRankRequestHandler(ISchoolManagementRepository<SailorRank> SailorRankRepository)
        {
            _SailorRankRepository = SailorRankRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSailorRankRequest request, CancellationToken cancellationToken)
        {
            ICollection<SailorRank> codeValues = await _SailorRankRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SailorRankId
            }).ToList();
            return selectModels;
        }
    }
}
