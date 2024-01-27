using SchoolManagement.Application.Features.Trades.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Trade;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Trades.Handlers.Queries
{
    public class GetTradeListRequestHandler : IRequestHandler<GetTradeListRequest, PagedResult<TradeDto>>
    {

        private readonly ISchoolManagementRepository<Trade> _TradeRepository;

        private readonly IMapper _mapper;

        public GetTradeListRequestHandler(ISchoolManagementRepository<Trade> TradeRepository, IMapper mapper)
        {
            _TradeRepository = TradeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TradeDto>> Handle(GetTradeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Trade> Trades = _TradeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Trades.Count();
            Trades = Trades.OrderByDescending(x => x.TradeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TradeDtos = _mapper.Map<List<TradeDto>>(Trades);
            var result = new PagedResult<TradeDto>(TradeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
