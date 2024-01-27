using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Ranks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Queries
{
    public class GetSelectedRankRequestHandler : IRequestHandler<GetSelectedRankRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Rank> _RankRepository;


        public GetSelectedRankRequestHandler(ISchoolManagementRepository<Rank> RankRepository)
        {
            _RankRepository = RankRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedRankRequest request, CancellationToken cancellationToken)
        {
            ICollection<Rank> codeValues = await _RankRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.RankId
            }).ToList();
            return selectModels;
        }
    }
}
