using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries
{
    public class GetSelectedStockTransferNsdRequest : IRequest<List<SelectedModel>>
    {
    }
}
