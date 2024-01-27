using MediatR;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Commands
{
    public class CreateConditionOfItemCommand : IRequest<BaseCommandResponse>
    {
        public CreateConditionOfItemDto ConditionOfItemDto { get; set; }
    }
}
