namespace SchoolManagement.Application.DTOs.CstTec
{
    public interface ICstTecDto
    {
        public int CstTecId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
