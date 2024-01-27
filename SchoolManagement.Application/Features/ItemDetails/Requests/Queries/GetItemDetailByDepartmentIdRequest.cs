using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetItemDetailByDepartmentIdRequest : IRequest<List<ItemDetailDto>>
    {  
        public int DepartmentNameId { get; set; }
        public int SparesCategoryId { get; set; } 
    } 
}
 
 