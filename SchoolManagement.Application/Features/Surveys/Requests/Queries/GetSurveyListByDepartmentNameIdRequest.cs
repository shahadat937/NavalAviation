using MediatR;
using SchoolManagement.Application.DTOs.Survey;

namespace SchoolManagement.Application.Features.Surveys.Requests.Queries
{
    public class GetSurveyListByDepartmentNameIdRequest : IRequest<List<SurveyDto>>
    {
        
        public int DepartmentNameId { get; set; }
    } 
}

