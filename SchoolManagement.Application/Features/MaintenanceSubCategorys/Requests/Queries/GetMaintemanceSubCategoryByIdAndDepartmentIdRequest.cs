using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetMaintemanceSubCategoryByIdAndDepartmentIdRequest : IRequest<List<MaintenanceSubCategoryDto>>
    {  
        public int DepartmentNameId { get; set; }   
        public int MaintenanceCategoryId { get; set; }    
    } 
}
 
 