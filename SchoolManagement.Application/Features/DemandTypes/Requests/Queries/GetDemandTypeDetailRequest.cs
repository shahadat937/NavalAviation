using MediatR;
using SchoolManagement.Application.DTOs.DemandType;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Queries
{
    public class GetDemandTypeDetailRequest : IRequest<DemandTypeDto>
    {
        public int DemandTypeId { get; set; }
    }
}
