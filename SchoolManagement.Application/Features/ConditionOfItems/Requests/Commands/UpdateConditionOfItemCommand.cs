using MediatR;
using SchoolManagement.Application.DTOs.ConditionOfItems;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands
{
    public class UpdateConditionOfItemCommand : IRequest<Unit>
    { 
        public ConditionOfItemDto ConditionOfItemDto { get; set; }
    }
}
 