using MediatR;
using SchoolManagement.Application.DTOs.Survey;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Surveys.Requests.Commands
{
    public class CreateSurveyCommand : IRequest<BaseCommandResponse>
    {
        public CreateSurveyDto SurveyDto { get; set; }
    }
}
