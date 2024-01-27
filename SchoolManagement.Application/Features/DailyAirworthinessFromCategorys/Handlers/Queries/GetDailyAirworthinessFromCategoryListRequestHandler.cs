using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Queries
{
    public class GetDailyAirworthinessFromCategoryListRequestHandler : IRequestHandler<GetDailyAirworthinessFromCategoryListRequest, PagedResult<DailyAirworthinessFromCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFromCategory> _DailyAirworthinessFromCategoryRepository;

        private readonly IMapper _mapper;

        public GetDailyAirworthinessFromCategoryListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFromCategory> DailyAirworthinessFromCategoryRepository, IMapper mapper)
        {
            _DailyAirworthinessFromCategoryRepository = DailyAirworthinessFromCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DailyAirworthinessFromCategoryDto>> Handle(GetDailyAirworthinessFromCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DailyAirworthinessFromCategory> UTOfficerCategories = _DailyAirworthinessFromCategoryRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DailyAirworthinessFromCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DailyAirworthinessFromCategoryDtos = _mapper.Map<List<DailyAirworthinessFromCategoryDto>>(UTOfficerCategories);
            var result = new PagedResult<DailyAirworthinessFromCategoryDto>(DailyAirworthinessFromCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
