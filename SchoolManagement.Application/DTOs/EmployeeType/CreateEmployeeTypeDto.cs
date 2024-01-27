using SchoolManagement.Application.DTOs.EmployeeType;

namespace SchoolManagement.Application.DTOs.EmployeeType 
{
    public class CreateEmployeeTypeDto : IEmployeeTypeDto
    {
        public int EmployeeTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
