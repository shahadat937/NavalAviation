namespace SchoolManagement.Application.DTOs.EmployeeType
{
    public interface IEmployeeTypeDto
    {
        public int EmployeeTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
