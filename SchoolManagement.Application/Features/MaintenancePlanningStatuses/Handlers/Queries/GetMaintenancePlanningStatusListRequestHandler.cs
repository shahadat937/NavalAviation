using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MaintenancePlanningStatuses.Requests.Queries;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;

namespace SchoolManagement.Application.Features.MaintenancePlanningStatuses.Handlers.Queries
{
    public class GetMaintenancePlanningStatusListRequestHandler : IRequestHandler<GetMaintenancePlanningStatusListRequest, PagedResult<MaintenancePlanningStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MaintenancePlanningStatus> _MaintenancePlanningStatusRepository;

        private readonly IMapper _mapper;

        public GetMaintenancePlanningStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MaintenancePlanningStatus> MaintenancePlanningStatusRepository, IMapper mapper)
        {
            _MaintenancePlanningStatusRepository = MaintenancePlanningStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenancePlanningStatusDto>> Handle(GetMaintenancePlanningStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.MaintenancePlanningStatus> MaintenancePlanningStatuss = _MaintenancePlanningStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MaintenancePlanningStatuss.Count();
            MaintenancePlanningStatuss = MaintenancePlanningStatuss.OrderByDescending(x => x.MaintenancePlanningStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenancePlanningStatusDtos = _mapper.Map<List<MaintenancePlanningStatusDto>>(MaintenancePlanningStatuss);
            var result = new PagedResult<MaintenancePlanningStatusDto>(MaintenancePlanningStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
