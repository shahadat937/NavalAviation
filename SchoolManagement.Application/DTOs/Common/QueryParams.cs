namespace SchoolManagement.Application.DTOs.Common
{
    public class QueryParams
    {
        public string? SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
