using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewDetailRequest : IRequest<TrainingCrewDto>
    {
        public int TrainingCrewId { get; set; }
    }
}
