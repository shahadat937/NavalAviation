using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetSelectedItemDetailRequest : IRequest<List<SelectedModel>>
    {
      public int DepartmentNameId { get; set; }
      public int SparesCategoryId { get; set; }
    }
}
