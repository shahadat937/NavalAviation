using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Queries
{
    public class GetItemCategoryTypeListRequestHandler : IRequestHandler<GetItemCategoryTypeListRequest, PagedResult<ItemCategoryTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemCategoryType> _ItemCategoryTypeRepository;

        private readonly IMapper _mapper;

        public GetItemCategoryTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemCategoryType> ItemCategoryTypeRepository, IMapper mapper)
        {
            _ItemCategoryTypeRepository = ItemCategoryTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemCategoryTypeDto>> Handle(GetItemCategoryTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemCategoryType> UTOfficerCategories = _ItemCategoryTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ItemCategoryTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemCategoryTypeDtos = _mapper.Map<List<ItemCategoryTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<ItemCategoryTypeDto>(ItemCategoryTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
