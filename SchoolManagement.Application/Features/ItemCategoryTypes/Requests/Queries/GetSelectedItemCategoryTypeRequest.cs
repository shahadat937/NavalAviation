using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries
{
    public class GetSelectedItemCategoryTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
