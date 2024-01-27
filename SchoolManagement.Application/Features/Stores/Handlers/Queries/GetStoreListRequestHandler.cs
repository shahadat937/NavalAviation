using SchoolManagement.Application.Features.Stores.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Stores.Handlers.Queries
{
    public class GetStoreListRequestHandler : IRequestHandler<GetStoreListRequest, PagedResult<StoreDto>>
    {

        private readonly ISchoolManagementRepository<Store> _StoreRepository;

        private readonly IMapper _mapper;

        public GetStoreListRequestHandler(ISchoolManagementRepository<Store> StoreRepository, IMapper mapper)
        {
            _StoreRepository = StoreRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StoreDto>> Handle(GetStoreListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Store> UTOfficerCategories = _StoreRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.StoreId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var StoreDtos = _mapper.Map<List<StoreDto>>(UTOfficerCategories);
            var result = new PagedResult<StoreDto>(StoreDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
