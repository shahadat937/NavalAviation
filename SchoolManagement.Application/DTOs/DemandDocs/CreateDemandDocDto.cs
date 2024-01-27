namespace SchoolManagement.Application.DTOs.DemandDocs
{
    public class CreateDemandDocDto : IDemandDocDto
    {
        public int DemandDocId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
 