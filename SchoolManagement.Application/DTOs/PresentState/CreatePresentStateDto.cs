namespace SchoolManagement.Application.DTOs.PresentState
{
    public class CreatePresentStateDto : IPresentStateDto
    {
        public int PresentStateId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
 