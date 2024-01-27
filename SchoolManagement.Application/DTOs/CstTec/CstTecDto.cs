using SchoolManagement.Application.DTOs.CstTec;

namespace SchoolManagement.Application.DTOs.CstTec
{
    public class CstTecDto : ICstTecDto
    {
        public int CstTecId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
