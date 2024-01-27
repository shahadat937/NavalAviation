using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Commands
{
    public class CreateTrainingCrewCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainingCrewDto TrainingCrewDto { get; set; }
    }
}
