namespace SchoolManagement.Application.DTOs.FiscalYears
{
    public class FiscalYearDto : IFiscalYearDto
    {
        public int FiscalYearId { get; set; }
        public string? FiscalYearName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
