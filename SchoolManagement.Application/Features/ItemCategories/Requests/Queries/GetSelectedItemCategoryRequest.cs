using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemCategories.Requests.Queries
{
    public class GetSelectedItemCategoryRequest : IRequest<List<SelectedModel>>
    {
      public int? spareCategoryId { get; set; }
    }
} 
