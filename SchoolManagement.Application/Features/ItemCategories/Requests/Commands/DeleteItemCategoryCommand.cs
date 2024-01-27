using MediatR;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Commands
{
    public class DeleteItemCategoryCommand : IRequest
    {
        public int ItemCategoryId { get; set; }
    }
} 
