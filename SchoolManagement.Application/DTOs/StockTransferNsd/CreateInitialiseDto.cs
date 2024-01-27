using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.StockTransferNsd;

namespace SchoolManagement.Application.DTOs.StockTransferNsd
{
    public class CreateInitialiseDto
    {
        public IFormFile Document { get; set; }
        public CreateStockTransferNsdDto StockTransferNsdForm { get; set; }
    }
}
