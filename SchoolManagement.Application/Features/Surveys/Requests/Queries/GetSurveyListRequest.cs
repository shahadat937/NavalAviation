using MediatR;
using SchoolManagement.Application.DTOs.Survey;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Surveys.Requests.Queries
{
    public class GetSurveyListRequest : IRequest<PagedResult<SurveyDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
