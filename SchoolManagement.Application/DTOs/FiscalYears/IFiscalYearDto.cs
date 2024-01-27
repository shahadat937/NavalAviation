namespace SchoolManagement.Application.DTOs.FiscalYears
{
    public interface IFiscalYearDto
    {
        public string? FiscalYearName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
