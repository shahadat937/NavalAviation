using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Surveys.Requests.Queries
{
    public class GetSelectedSurveyRequest : IRequest<List<SelectedModel>>
    {
    }
}
