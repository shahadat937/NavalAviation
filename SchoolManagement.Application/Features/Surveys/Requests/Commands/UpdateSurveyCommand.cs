using MediatR;
using SchoolManagement.Application.DTOs.Survey;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Surveys.Requests.Commands
{
    public class UpdateSurveyCommand : IRequest<Unit>
    {
        public SurveyDto SurveyDto { get; set; }
    }
}
