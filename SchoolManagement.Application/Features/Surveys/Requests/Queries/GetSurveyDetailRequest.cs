using MediatR;
using SchoolManagement.Application.DTOs.Survey;

namespace SchoolManagement.Application.Features.Surveys.Requests.Queries
{
    public class GetSurveyDetailRequest : IRequest<SurveyDto>
    {
        public int SurveyId { get; set; }
    }
}
