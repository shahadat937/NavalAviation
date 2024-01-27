namespace SchoolManagement.Application.DTOs.LifeLimitItemRunningHour
{
    public interface ILifeLimitItemRunningHourDto
    {
        public int LifeLimitItemRunningHourId { get; set; }
        public int? LifeLimitItemId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? ItemDetailId { get; set; }
        public string? SlNo { get; set; }
        public DateTime? FlightDate { get; set; }
        public string? FlightTimeHr { get; set; }
        public string? FlightTimeMin { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    } 
}
