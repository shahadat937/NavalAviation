using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries
{
    public class GetSelectedShelfLifeCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
