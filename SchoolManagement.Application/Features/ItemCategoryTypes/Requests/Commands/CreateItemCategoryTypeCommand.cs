using MediatR;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands
{
    public class CreateItemCategoryTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemCategoryTypeDto ItemCategoryTypeDto { get; set; }
    }
}
