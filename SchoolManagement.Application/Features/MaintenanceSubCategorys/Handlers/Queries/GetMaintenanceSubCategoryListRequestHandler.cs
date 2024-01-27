using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetMaintenanceSubCategoryListRequestHandler : IRequestHandler<GetMaintenanceSubCategoryListRequest, PagedResult<MaintenanceSubCategoryDto>>
    {

        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;

        private readonly IMapper _mapper;

        public GetMaintenanceSubCategoryListRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository, IMapper mapper)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenanceSubCategoryDto>> Handle(GetMaintenanceSubCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MaintenanceSubCategory> UTOfficerCategories = _MaintenanceSubCategoryRepository.FilterWithInclude(x => (x.SubCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "MaintenanceCategory", "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MaintenanceSubCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenanceSubCategoryDtos = _mapper.Map<List<MaintenanceSubCategoryDto>>(UTOfficerCategories);
            var result = new PagedResult<MaintenanceSubCategoryDto>(MaintenanceSubCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
