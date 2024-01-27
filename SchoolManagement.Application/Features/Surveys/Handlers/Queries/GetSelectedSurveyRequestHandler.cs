using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Surveys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Surveys.Handlers.Queries
{
    public class GetSelectedSurveyRequestHandler : IRequestHandler<GetSelectedSurveyRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Survey> _SurveyRepository;


        public GetSelectedSurveyRequestHandler(ISchoolManagementRepository<Survey> SurveyRepository)
        {
            _SurveyRepository = SurveyRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSurveyRequest request, CancellationToken cancellationToken)
        {
            ICollection<Survey> codeValues = await _SurveyRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.SurveyNumber,
                Value = x.SurveyId
            }).ToList();
            return selectModels;
        }
    }
}
