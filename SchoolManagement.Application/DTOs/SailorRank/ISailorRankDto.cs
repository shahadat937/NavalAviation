namespace SchoolManagement.Application.DTOs.SailorRank
{
    public interface ISailorRankDto
    {
       public int SailorRankId { get; set; }
       public string? Name { get; set; }
       public string? Remarks { get; set; }
       public bool IsActive { get; set; }
    }
}
