using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries
{
    public class ChangeStockTransfarNsdStatusRequest : IRequest<Unit>
    {
        public int StockTransferNsdId { get; set; }
        public int status { get; set; }
    }
}
