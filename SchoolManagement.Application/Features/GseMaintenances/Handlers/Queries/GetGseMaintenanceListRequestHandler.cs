using SchoolManagement.Application.Features.GseMaintenances.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseMaintenance;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseMaintenances.Handlers.Queries
{
    public class GetGseMaintenanceListRequestHandler : IRequestHandler<GetGseMaintenanceListRequest, PagedResult<GseMaintenanceDto>>
    {

        private readonly ISchoolManagementRepository<GseMaintenance> _GseMaintenanceRepository;

        private readonly IMapper _mapper;

        public GetGseMaintenanceListRequestHandler(ISchoolManagementRepository<GseMaintenance> GseMaintenanceRepository, IMapper mapper)
        {
            _GseMaintenanceRepository = GseMaintenanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GseMaintenanceDto>> Handle(GetGseMaintenanceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<GseMaintenance> GseMaintenances = _GseMaintenanceRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "DepartmentName", "GseItemName", "GseMaintenanceScheduleName", "GseScheduleWorkType");
            var totalCount = GseMaintenances.Count();
            GseMaintenances = GseMaintenances.OrderByDescending(x => x.GseMaintenanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GseMaintenanceDtos = _mapper.Map<List<GseMaintenanceDto>>(GseMaintenances);
            var result = new PagedResult<GseMaintenanceDto>(GseMaintenanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
