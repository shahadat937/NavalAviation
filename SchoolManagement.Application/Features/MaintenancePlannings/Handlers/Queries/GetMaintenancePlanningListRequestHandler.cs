using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetMaintenancePlanningListRequestHandler : IRequestHandler<GetMaintenancePlanningListRequest, PagedResult<MaintenancePlanningDto>>
    {

        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;

        private readonly IMapper _mapper;

        public GetMaintenancePlanningListRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository, IMapper mapper)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenancePlanningDto>> Handle(GetMaintenancePlanningListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MaintenancePlanning> UTOfficerCategories = _MaintenancePlanningRepository.FilterWithInclude(x => (x.SlNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "AirCraftName", "MaintenanceType", "MaintenanceCategory", "MaintenanceSubCategory", "MaintenancePlanningStatus");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MaintenancePlanningId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenancePlanningDtos = _mapper.Map<List<MaintenancePlanningDto>>(UTOfficerCategories);
            var result = new PagedResult<MaintenancePlanningDto>(MaintenancePlanningDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
