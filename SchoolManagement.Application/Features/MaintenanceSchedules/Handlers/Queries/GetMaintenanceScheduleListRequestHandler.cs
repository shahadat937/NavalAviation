using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetMaintenanceScheduleListRequestHandler : IRequestHandler<GetMaintenanceScheduleListRequest, PagedResult<MaintenanceScheduleDto>>
    {

        private readonly ISchoolManagementRepository<MaintenanceSchedule> _MaintenanceScheduleRepository;

        private readonly IMapper _mapper;

        public GetMaintenanceScheduleListRequestHandler(ISchoolManagementRepository<MaintenanceSchedule> MaintenanceScheduleRepository, IMapper mapper)
        {
            _MaintenanceScheduleRepository = MaintenanceScheduleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenanceScheduleDto>> Handle(GetMaintenanceScheduleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MaintenanceSchedule> UTOfficerCategories = _MaintenanceScheduleRepository.FilterWithInclude(x => (x.SlNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MaintenanceScheduleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenanceScheduleDtos = _mapper.Map<List<MaintenanceScheduleDto>>(UTOfficerCategories);
            var result = new PagedResult<MaintenanceScheduleDto>(MaintenanceScheduleDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
