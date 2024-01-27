using MediatR;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Commands
{
    public class DeleteShelfLifeCategoryCommand : IRequest
    {
        public int ShelfLifeCategoryId { get; set; }
    }
}
