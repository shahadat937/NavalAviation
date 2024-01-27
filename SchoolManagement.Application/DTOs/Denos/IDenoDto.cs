namespace SchoolManagement.Application.DTOs.Denos
{
    public interface IDenoDto
    {
        public int DenoId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
