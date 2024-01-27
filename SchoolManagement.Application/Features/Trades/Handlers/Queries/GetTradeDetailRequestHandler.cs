using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Trade;
using SchoolManagement.Application.Features.Trades.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Trades.Handlers.Queries
{
    public class GetTradeDetailRequestHandler : IRequestHandler<GetTradeDetailRequest, TradeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Trade> _TradeRepository;
        public GetTradeDetailRequestHandler(ISchoolManagementRepository<Trade> TradeRepository, IMapper mapper)
        {
            _TradeRepository = TradeRepository;
            _mapper = mapper;
        }
        public async Task<TradeDto> Handle(GetTradeDetailRequest request, CancellationToken cancellationToken)
        {
            var Trade = await _TradeRepository.Get(request.TradeId);
            return _mapper.Map<TradeDto>(Trade);
        }
    }
}
