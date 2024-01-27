namespace SchoolManagement.Application.DTOs.Trade
{
    public interface ITradeDto
    {
        public int TradeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    } 
}
