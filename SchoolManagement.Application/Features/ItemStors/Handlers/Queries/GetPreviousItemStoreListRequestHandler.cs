using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetPreviousItemStoreListRequestHandler : IRequestHandler<GetPreviousItemStoreListRequest, PagedResult<ItemStorDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemStor> _ItemStorRepository;

        private readonly IMapper _mapper;

        public GetPreviousItemStoreListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemStor> ItemStorRepository, IMapper mapper)
        {
            _ItemStorRepository = ItemStorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemStorDto>> Handle(GetPreviousItemStoreListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemStor> UTOfficerCategories = _ItemStorRepository.FilterWithInclude(x => (x.ItemSerNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ItemStorId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemStorDtos = _mapper.Map<List<ItemStorDto>>(UTOfficerCategories);
            var result = new PagedResult<ItemStorDto>(ItemStorDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
