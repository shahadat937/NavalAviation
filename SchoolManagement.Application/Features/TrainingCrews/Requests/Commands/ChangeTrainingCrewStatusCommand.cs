using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Commands
{
    public class ChangeTrainingCrewStatusCommand : IRequest<BaseCommandResponse>
    { 
      public int TrainingCrewId { get; set; }
      public int OfficerStatusId { get; set; }
  }
}
