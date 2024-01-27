using MediatR;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands
{
    public class CreateOccasionOfDemandCommand : IRequest<BaseCommandResponse>
    {
        public CreateOccasionOfDemandDto OccasionOfDemandDto { get; set; }
    }
}
