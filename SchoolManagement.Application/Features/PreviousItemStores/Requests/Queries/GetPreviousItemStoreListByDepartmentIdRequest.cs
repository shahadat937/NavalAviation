using MediatR;
using SchoolManagement.Application.DTOs.PreviousItemStore;

namespace SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries
{
    public class GetPreviousItemStoreListByDepartmentIdRequest : IRequest<List<PreviousItemStoreDto>>
    {  
        public int DepartmentNameId { get; set; }   
    } 
}
 
 