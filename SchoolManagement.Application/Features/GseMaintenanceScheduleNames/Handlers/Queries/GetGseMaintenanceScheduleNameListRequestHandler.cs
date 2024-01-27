using SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenanceScheduleName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenanceScheduleNames.Handlers.Queries
{
    public class GetGseMaintenanceScheduleNameListRequestHandler : IRequestHandler<GetGseMaintenanceScheduleNameListRequest, PagedResult<GseMaintenanceScheduleNameDto>>
    {

        private readonly ISchoolManagementRepository<GseMaintenanceScheduleName> _GseMaintenanceScheduleNameRepository;

        private readonly IMapper _mapper;

        public GetGseMaintenanceScheduleNameListRequestHandler(ISchoolManagementRepository<GseMaintenanceScheduleName> GseMaintenanceScheduleNameRepository, IMapper mapper)
        {
            _GseMaintenanceScheduleNameRepository = GseMaintenanceScheduleNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GseMaintenanceScheduleNameDto>> Handle(GetGseMaintenanceScheduleNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<GseMaintenanceScheduleName> GseMaintenanceScheduleNames = _GseMaintenanceScheduleNameRepository.FilterWithInclude(x => (x.ScheduleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = GseMaintenanceScheduleNames.Count();
            GseMaintenanceScheduleNames = GseMaintenanceScheduleNames.OrderByDescending(x => x.GseMaintenanceScheduleNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GseMaintenanceScheduleNameDtos = _mapper.Map<List<GseMaintenanceScheduleNameDto>>(GseMaintenanceScheduleNames);
            var result = new PagedResult<GseMaintenanceScheduleNameDto>(GseMaintenanceScheduleNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
