using MediatR;

namespace SchoolManagement.Application.Features.Surveys.Requests.Commands
{
    public class DeleteSurveyCommand : IRequest
    {
        public int SurveyId { get; set; }
    }
}
