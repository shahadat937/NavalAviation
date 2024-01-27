using MediatR;
using SchoolManagement.Application.DTOs.RetirementType;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Queries
{
    public class GetRetirementTypeDetailRequest : IRequest<RetirementTypeDto>
    {
        public int RetirementTypeId { get; set; }
    }
}
