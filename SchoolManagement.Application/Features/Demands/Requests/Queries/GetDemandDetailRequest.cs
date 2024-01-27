using MediatR;
using SchoolManagement.Application.DTOs.Demands;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetDemandDetailRequest : IRequest<DemandDto>
    {
        public int DemandId { get; set; }
    }
}
