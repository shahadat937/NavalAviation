using AutoMapper;
using SchoolManagement.Application.DTOs.Shop;
using SchoolManagement.Application.Features.Shops.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Shops.Handlers.Queries
{
    public class GetShopListRequestHandler : IRequestHandler<GetShopListRequest, PagedResult<ShopDto>>
    {

        private readonly ISchoolManagementRepository<Shop> _ShopRepository;

        private readonly IMapper _mapper;

        public GetShopListRequestHandler(ISchoolManagementRepository<Shop> ShopRepository, IMapper mapper)
        {
            _ShopRepository = ShopRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ShopDto>> Handle(GetShopListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Shop> Shops = _ShopRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Shops.Count();
            Shops = Shops.OrderByDescending(x => x.ShopId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ShopDtos = _mapper.Map<List<ShopDto>>(Shops);
            var result = new PagedResult<ShopDto>(ShopDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
