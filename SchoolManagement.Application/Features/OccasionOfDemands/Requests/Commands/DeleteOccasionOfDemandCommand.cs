using MediatR;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Commands
{
    public class DeleteOccasionOfDemandCommand : IRequest
    {
        public int OccasionOfDemandId { get; set; }
    }
}
