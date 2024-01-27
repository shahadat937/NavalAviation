namespace SchoolManagement.Application.DTOs.MaintenancePlanningStatus
{
    public interface IMaintenancePlanningStatusDto
    {
        public int MaintenancePlanningStatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
