namespace SchoolManagement.Application.DTOs.DemandStatus
{
    public interface IDemandStatusDto
    {
        public int DemandStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    } 
}
