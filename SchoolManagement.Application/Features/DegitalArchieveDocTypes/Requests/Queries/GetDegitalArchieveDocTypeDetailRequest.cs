using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries
{
    public class GetDegitalArchieveDocTypeDetailRequest : IRequest<DegitalArchieveDocTypeDto>
    {
        public int DegitalArchieveDocTypeId { get; set; }
    }
}
