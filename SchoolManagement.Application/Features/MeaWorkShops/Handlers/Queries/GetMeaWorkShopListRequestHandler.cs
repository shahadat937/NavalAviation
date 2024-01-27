using SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Queries
{
    public class GetMeaWorkShopListRequestHandler : IRequestHandler<GetMeaWorkShopListRequest, PagedResult<MeaWorkShopDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaWorkShop> _MeaWorkShopRepository;

        private readonly IMapper _mapper;

        public GetMeaWorkShopListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaWorkShop> MeaWorkShopRepository, IMapper mapper)
        {
            _MeaWorkShopRepository = MeaWorkShopRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MeaWorkShopDto>> Handle(GetMeaWorkShopListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.MeaWorkShop> UTOfficerCategories = _MeaWorkShopRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MeaWorkShopId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MeaWorkShopDtos = _mapper.Map<List<MeaWorkShopDto>>(UTOfficerCategories);
            var result = new PagedResult<MeaWorkShopDto>(MeaWorkShopDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
