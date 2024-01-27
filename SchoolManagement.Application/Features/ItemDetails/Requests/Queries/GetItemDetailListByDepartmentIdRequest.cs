using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Queries
{
    public class GetItemDetailListByDepartmentIdRequest : IRequest<List<ItemDetailDto>>
    {  
        public int DepartmentNameId { get; set; }   
        //public int MaintenanceCategoryId { get; set; }    
    } 
}
 
 