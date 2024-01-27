using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewListRequest : IRequest<PagedResult<TrainingCrewDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
