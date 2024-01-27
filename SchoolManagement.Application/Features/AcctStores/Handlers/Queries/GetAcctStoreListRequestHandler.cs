using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.Features.AcctStores.Requests.Queries;

namespace SchoolManagement.Application.Features.AcctStores.Handlers.Queries
{
    public class GetAcctStoreListRequestHandler : IRequestHandler<GetAcctStoreListRequest, PagedResult<AcctStoreDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AcctStore> _AcctStoreRepository;

        private readonly IMapper _mapper;

        public GetAcctStoreListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AcctStore> AcctStoreRepository, IMapper mapper)
        {
            _AcctStoreRepository = AcctStoreRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AcctStoreDto>> Handle(GetAcctStoreListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.AcctStore> AcctStores = _AcctStoreRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = AcctStores.Count();
            AcctStores = AcctStores.OrderByDescending(x => x.AcctStoreId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AcctStoreDtos = _mapper.Map<List<AcctStoreDto>>(AcctStores);
            var result = new PagedResult<AcctStoreDto>(AcctStoreDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
