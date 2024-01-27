using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetSelectedItemDetailForStockTransferNsdRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }
    }
}
