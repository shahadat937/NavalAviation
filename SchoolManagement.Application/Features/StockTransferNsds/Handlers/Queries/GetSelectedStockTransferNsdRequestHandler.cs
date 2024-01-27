using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Queries
{
    public class GetSelectedStockTransferNsdRequestHandler : IRequestHandler<GetSelectedStockTransferNsdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<StockTransferNsd> _StockTransferNsdRepository;


        public GetSelectedStockTransferNsdRequestHandler(ISchoolManagementRepository<StockTransferNsd> StockTransferNsdRepository)
        {
            _StockTransferNsdRepository = StockTransferNsdRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedStockTransferNsdRequest request, CancellationToken cancellationToken)
        {
            ICollection<StockTransferNsd> codeValues = await _StockTransferNsdRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AvailableQty,
                Value = x.StockTransferNsdId
            }).ToList();
            return selectModels;
        }
    }
}
