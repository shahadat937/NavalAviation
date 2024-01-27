using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ItemCategorys;
using SchoolManagement.Application.Features.ItemCategories.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Queries
{
    public class GetItemCategoryListRequestHandler : IRequestHandler<GetItemCategoryListRequest, PagedResult<ItemCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemCategory> _ItemCategoryRepository;

        private readonly IMapper _mapper;

        public GetItemCategoryListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemCategory> ItemCategoryRepository, IMapper mapper)
        {
            _ItemCategoryRepository = ItemCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemCategoryDto>> Handle(GetItemCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemCategory> ItemCategorys = _ItemCategoryRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ItemCategorys.Count();
            ItemCategorys = ItemCategorys.OrderByDescending(x => x.ItemCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemCategoryDtos = _mapper.Map<List<ItemCategoryDto>>(ItemCategorys);
            var result = new PagedResult<ItemCategoryDto>(ItemCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
