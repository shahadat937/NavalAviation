namespace SchoolManagement.Application.DTOs.PresentBillets
{
    public interface IPresentBilletDto
    {
      public int PresentBilletId { get; set; }
      public string PresentBilletName { get; set; }
      public int? MenuPosition { get; set; }
      public bool IsActive { get; set; }
  }
}
