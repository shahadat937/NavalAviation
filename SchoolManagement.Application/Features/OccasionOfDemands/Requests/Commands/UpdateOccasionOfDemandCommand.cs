using MediatR;
using SchoolManagement.Application.DTOs.OccasionOfDemand;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands
{
    public class UpdateOccasionOfDemandCommand : IRequest<Unit>
    {
        public OccasionOfDemandDto OccasionOfDemandDto { get; set; }
    }
}
