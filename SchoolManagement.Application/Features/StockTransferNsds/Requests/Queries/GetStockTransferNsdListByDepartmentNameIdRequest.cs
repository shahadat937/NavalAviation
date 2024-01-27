using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries
{
    public class GetStockTransferNsdListByDepartmentNameIdRequest : IRequest<List<StockTransferNsdDto>>
    {
        
        public int DepartmentNameId { get; set; }
        public int Status { get; set; }
    } 
}

