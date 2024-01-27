using MediatR;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands
{
    public class DeleteConditionOfItemCommand : IRequest
    {
        public int ConditionOfItemId { get; set; }
    }
} 
 