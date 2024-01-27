using SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Handlers.Queries
{
    public class GetMaintenanceTypeListRequestHandler : IRequestHandler<GetMaintenanceTypeListRequest, PagedResult<MaintenanceTypeDto>>
    {

        private readonly ISchoolManagementRepository<MaintenanceType> _MaintenanceTypeRepository;

        private readonly IMapper _mapper;

        public GetMaintenanceTypeListRequestHandler(ISchoolManagementRepository<MaintenanceType> MaintenanceTypeRepository, IMapper mapper)
        {
            _MaintenanceTypeRepository = MaintenanceTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenanceTypeDto>> Handle(GetMaintenanceTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MaintenanceType> UTOfficerCategories = _MaintenanceTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MaintenanceTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenanceTypeDtos = _mapper.Map<List<MaintenanceTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<MaintenanceTypeDto>(MaintenanceTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
