using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Queries
{
    public class GetShelfLifeCategoryListRequestHandler : IRequestHandler<GetShelfLifeCategoryListRequest, PagedResult<ShelfLifeCategoryDto>>
    {

        private readonly ISchoolManagementRepository<ShelfLifeCategory> _ShelfLifeCategoryRepository;

        private readonly IMapper _mapper;

        public GetShelfLifeCategoryListRequestHandler(ISchoolManagementRepository<ShelfLifeCategory> ShelfLifeCategoryRepository, IMapper mapper)
        {
            _ShelfLifeCategoryRepository = ShelfLifeCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ShelfLifeCategoryDto>> Handle(GetShelfLifeCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ShelfLifeCategory> UTOfficerCategories = _ShelfLifeCategoryRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ShelfLifeCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ShelfLifeCategoryDtos = _mapper.Map<List<ShelfLifeCategoryDto>>(UTOfficerCategories);
            var result = new PagedResult<ShelfLifeCategoryDto>(ShelfLifeCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
