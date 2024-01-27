using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Commands
{
    public class UpdateTrainingCrewCommand : IRequest<Unit>
    {
        public TrainingCrewDto TrainingCrewDto { get; set; }
    }
}
