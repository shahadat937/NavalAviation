using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIditemDetailIdFromItemStoreRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; }
        public int ItemDetailId { get; set; }
    }
}
