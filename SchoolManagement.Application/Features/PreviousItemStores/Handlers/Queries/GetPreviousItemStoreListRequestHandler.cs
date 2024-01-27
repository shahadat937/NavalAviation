using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Queries
{
    public class GetPreviousItemStoreListRequestHandler : IRequestHandler<GetPreviousItemStoreListRequest, PagedResult<PreviousItemStoreDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PreviousItemStore> _PreviousItemStoreRepository;

        private readonly IMapper _mapper;

        public GetPreviousItemStoreListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PreviousItemStore> PreviousItemStoreRepository, IMapper mapper)
        {
            _PreviousItemStoreRepository = PreviousItemStoreRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PreviousItemStoreDto>> Handle(GetPreviousItemStoreListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.PreviousItemStore> PreviousItemStores = _PreviousItemStoreRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "ItemDetail", "Deno", "ItemCategory", "AcctStore");
            var totalCount = PreviousItemStores.Count();
            PreviousItemStores = PreviousItemStores.OrderByDescending(x => x.PreviousItemStoreId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PreviousItemStoreDtos = _mapper.Map<List<PreviousItemStoreDto>>(PreviousItemStores);
            var result = new PagedResult<PreviousItemStoreDto>(PreviousItemStoreDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
