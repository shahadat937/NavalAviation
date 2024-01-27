using MediatR;
using SchoolManagement.Application.DTOs.ItemCategoryType;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries
{
    public class GetItemCategoryTypeDetailRequest : IRequest<ItemCategoryTypeDto>
    {
        public int ItemCategoryTypeId { get; set; }
    }
}
