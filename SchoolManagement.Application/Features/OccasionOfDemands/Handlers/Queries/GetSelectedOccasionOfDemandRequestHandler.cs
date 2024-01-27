using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Queries
{
    public class GetSelectedOccasionOfDemandRequestHandler : IRequestHandler<GetSelectedOccasionOfDemandRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OccasionOfDemand> _OccasionOfDemandRepository;


        public GetSelectedOccasionOfDemandRequestHandler(ISchoolManagementRepository<OccasionOfDemand> OccasionOfDemandRepository)
        {
            _OccasionOfDemandRepository = OccasionOfDemandRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOccasionOfDemandRequest request, CancellationToken cancellationToken)
        {
            ICollection<OccasionOfDemand> codeValues = await _OccasionOfDemandRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.OccasionOfDemandId
            }).ToList();
            return selectModels;
        }
    }
}
