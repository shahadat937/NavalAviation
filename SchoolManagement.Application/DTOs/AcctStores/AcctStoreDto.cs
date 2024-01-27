namespace SchoolManagement.Application.DTOs.AcctStores
{
    public class AcctStoreDto : IAcctStoreDto
    {
        public int AcctStoreId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
