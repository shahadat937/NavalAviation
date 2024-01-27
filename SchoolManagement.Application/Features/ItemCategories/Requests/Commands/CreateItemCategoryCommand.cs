using MediatR;
using SchoolManagement.Application.DTOs.ItemCategorys; 
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Commands
{
    public class CreateItemCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemCategoryDto ItemCategoryDto { get; set; }
    }
}
