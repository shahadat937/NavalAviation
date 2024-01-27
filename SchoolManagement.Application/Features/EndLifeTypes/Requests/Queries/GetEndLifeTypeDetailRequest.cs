using MediatR;
using SchoolManagement.Application.DTOs.EndLifeTypes;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries
{
    public class GetEndLifeTypeDetailRequest : IRequest<EndLifeTypeDto>
    {
        public int EndLifeTypeId { get; set; }
    }
}
