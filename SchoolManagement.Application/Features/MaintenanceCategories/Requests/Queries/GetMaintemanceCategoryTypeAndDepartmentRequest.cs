using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;

namespace SchoolManagement.Application.Features.MaintenanceCategoriess.Requests.Queries
{
    public class GetMaintemanceCategoryTypeAndDepartmentRequest : IRequest<List<MaintenanceCategoryDto>>
    {
        public int MaintenanceTypeId { get; set; }  
        public int DepartmentNameId { get; set; }
    } 
}

 