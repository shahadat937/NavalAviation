using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.SparesCategorys;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Queries
{
    public class GetSparesCategoryListRequestHandler : IRequestHandler<GetSparesCategoryListRequest, PagedResult<SparesCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SparesCategory> _SparesCategoryRepository;

        private readonly IMapper _mapper;

        public GetSparesCategoryListRequestHandler(ISchoolManagementRepository<SparesCategory> SparesCategoryRepository, IMapper mapper)
        {
            _SparesCategoryRepository = SparesCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SparesCategoryDto>> Handle(GetSparesCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SparesCategory> SparesCategorys = _SparesCategoryRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SparesCategorys.Count();
            SparesCategorys = SparesCategorys.OrderByDescending(x => x.SparesCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SparesCategoryDtos = _mapper.Map<List<SparesCategoryDto>>(SparesCategorys);
            var result = new PagedResult<SparesCategoryDto>(SparesCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
