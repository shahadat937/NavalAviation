using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Queries
{
    public class GetStockTransferNsdListRequestHandler : IRequestHandler<GetStockTransferNsdListRequest, PagedResult<StockTransferNsdDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.StockTransferNsd> _StockTransferNsdRepository;

        private readonly IMapper _mapper;

        public GetStockTransferNsdListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.StockTransferNsd> StockTransferNsdRepository, IMapper mapper)
        {
            _StockTransferNsdRepository = StockTransferNsdRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StockTransferNsdDto>> Handle(GetStockTransferNsdListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.StockTransferNsd> UTOfficerCategories = _StockTransferNsdRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.StockTransferNsdId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var StockTransferNsdDtos = _mapper.Map<List<StockTransferNsdDto>>(UTOfficerCategories);
            var result = new PagedResult<StockTransferNsdDto>(StockTransferNsdDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
