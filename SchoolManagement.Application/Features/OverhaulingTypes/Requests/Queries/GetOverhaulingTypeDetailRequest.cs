using MediatR;
using SchoolManagement.Application.DTOs.OverhaulingType;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries
{
    public class GetOverhaulingTypeDetailRequest : IRequest<OverhaulingTypeDto>
    {
        public int OverhaulingTypeId { get; set; }
    }
}
