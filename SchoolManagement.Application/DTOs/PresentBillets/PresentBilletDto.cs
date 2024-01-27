namespace SchoolManagement.Application.DTOs.PresentBillets
{
    public class PresentBilletDto : IPresentBilletDto
    {
      public int PresentBilletId { get; set; }
      public string PresentBilletName { get; set; } = null!;
      public int? MenuPosition { get; set; }
      public bool IsActive { get; set; }
  }
}
