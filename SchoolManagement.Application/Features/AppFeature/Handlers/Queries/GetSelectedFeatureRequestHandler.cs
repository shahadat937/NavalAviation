using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AppFeature.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AppFeature.Handlers.Queries
{
    public class GetSelectedFeatureRequestHandler : IRequestHandler<GetSelectedFeatureRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Feature> _FeatureRepository;


        public GetSelectedFeatureRequestHandler(ISchoolManagementRepository<Feature> FeatureRepository)
        {
            _FeatureRepository = FeatureRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFeatureRequest request, CancellationToken cancellationToken)
        {
            ICollection<Feature> codeValues = await _FeatureRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.FeatureName,
                Value = x.FeatureId
            }).ToList();
            return selectModels;
        }
    }
}
