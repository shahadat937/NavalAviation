using SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseScheduleWorkType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Handlers.Queries
{
    public class GetGseScheduleWorkTypeListRequestHandler : IRequestHandler<GetGseScheduleWorkTypeListRequest, PagedResult<GseScheduleWorkTypeDto>>
    {

        private readonly ISchoolManagementRepository<GseScheduleWorkType> _GseScheduleWorkTypeRepository;

        private readonly IMapper _mapper;

        public GetGseScheduleWorkTypeListRequestHandler(ISchoolManagementRepository<GseScheduleWorkType> GseScheduleWorkTypeRepository, IMapper mapper)
        {
            _GseScheduleWorkTypeRepository = GseScheduleWorkTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GseScheduleWorkTypeDto>> Handle(GetGseScheduleWorkTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<GseScheduleWorkType> GseScheduleWorkTypes = _GseScheduleWorkTypeRepository.FilterWithInclude(x => (x.ScheduleWorkName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "GseMaintenanceScheduleName");
            var totalCount = GseScheduleWorkTypes.Count();
            GseScheduleWorkTypes = GseScheduleWorkTypes.OrderByDescending(x => x.GseScheduleWorkTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GseScheduleWorkTypeDtos = _mapper.Map<List<GseScheduleWorkTypeDto>>(GseScheduleWorkTypes);
            var result = new PagedResult<GseScheduleWorkTypeDto>(GseScheduleWorkTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
