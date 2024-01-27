namespace SchoolManagement.Application.DTOs.DemandAuthority
{
    public interface IDemandAuthorityDto 
    {
        public int DemandAuthorityId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
