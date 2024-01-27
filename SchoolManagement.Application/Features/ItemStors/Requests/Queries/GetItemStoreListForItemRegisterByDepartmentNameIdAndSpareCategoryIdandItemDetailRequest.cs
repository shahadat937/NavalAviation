using MediatR;
using SchoolManagement.Application.DTOs.ItemStor;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries 
{
    public class GetItemStoreListForItemRegisterByDepartmentNameIdAndSpareCategoryIdandItemDetailRequest : IRequest<List<ItemStorDto>>
    {  
        public int DepartmentNameId { get; set; } 
        public int SparesCategoryId { get; set; }
        public int ItemDetailId { get; set; } 
    }
}
