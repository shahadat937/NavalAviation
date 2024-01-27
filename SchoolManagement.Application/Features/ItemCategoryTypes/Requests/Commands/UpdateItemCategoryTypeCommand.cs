using MediatR;
using SchoolManagement.Application.DTOs.ItemCategoryType;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands
{
    public class UpdateItemCategoryTypeCommand : IRequest<Unit>
    {
        public ItemCategoryTypeDto ItemCategoryTypeDto { get; set; }
    }
}
