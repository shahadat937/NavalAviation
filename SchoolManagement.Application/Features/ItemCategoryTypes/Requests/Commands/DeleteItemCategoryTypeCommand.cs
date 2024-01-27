using MediatR;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Commands
{
    public class DeleteItemCategoryTypeCommand : IRequest
    {
        public int ItemCategoryTypeId { get; set; }
    }
}
