using MediatR;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries
{
    public class GetServiceLifeTypeDetailRequest : IRequest<ServiceLifeTypeDto>
    {
        public int ServiceLifeTypeId { get; set; }
    }
}
