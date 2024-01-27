using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Trades.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Trades.Handlers.Queries
{
    public class GetSelectedTradeRequestHandler : IRequestHandler<GetSelectedTradeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Trade> _TradeRepository;


        public GetSelectedTradeRequestHandler(ISchoolManagementRepository<Trade> TradeRepository)
        {
            _TradeRepository = TradeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTradeRequest request, CancellationToken cancellationToken)
        {
            ICollection<Trade> codeValues = await _TradeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.TradeId
            }).ToList();
            return selectModels;
        }
    }
}
