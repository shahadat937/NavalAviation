namespace SchoolManagement.Application.DTOs.DemandCompleteStatuses
{
    public interface IDemandCompleteStatusDto
    {
        public int DemandCompleteStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
