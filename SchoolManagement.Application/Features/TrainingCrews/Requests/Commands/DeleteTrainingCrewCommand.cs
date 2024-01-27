using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Commands
{
    public class DeleteTrainingCrewCommand : IRequest
    {
        public int TrainingCrewId { get; set; }
    }
}
