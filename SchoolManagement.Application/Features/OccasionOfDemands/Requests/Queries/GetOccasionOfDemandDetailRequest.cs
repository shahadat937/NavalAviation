using MediatR;
using SchoolManagement.Application.DTOs.OccasionOfDemand;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries
{
    public class GetOccasionOfDemandDetailRequest : IRequest<OccasionOfDemandDto>
    {
        public int OccasionOfDemandId { get; set; }
    }
}
