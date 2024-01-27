using MediatR;
using SchoolManagement.Application.DTOs.ItemTypes;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Queries
{
    public class GetItemTypeDetailRequest : IRequest<ItemTypeDto>
    {
        public int ItemTypeId { get; set; }
    }
}
