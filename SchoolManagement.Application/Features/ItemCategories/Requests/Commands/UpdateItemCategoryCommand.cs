using MediatR;
using SchoolManagement.Application.DTOs.ItemCategorys;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Commands
{
    public class UpdateItemCategoryCommand : IRequest<Unit> 
    { 
        public ItemCategoryDto ItemCategoryDto { get; set; }
    }
}
 