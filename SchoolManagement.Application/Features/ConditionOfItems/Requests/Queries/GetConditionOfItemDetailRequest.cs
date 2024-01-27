using MediatR;
using SchoolManagement.Application.DTOs.ConditionOfItems;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries
{
    public class GetConditionOfItemDetailRequest : IRequest<ConditionOfItemDto>
    {
        public int ConditionOfItemId { get; set; }
    }
}
