using SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItemRunningHour;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Handlers.Queries
{
    public class GetLifeLimitItemRunningHourListRequestHandler : IRequestHandler<GetLifeLimitItemRunningHourListRequest, PagedResult<LifeLimitItemRunningHourDto>>
    {

        private readonly ISchoolManagementRepository<LifeLimitItemRunningHour> _LifeLimitItemRunningHourRepository;

        private readonly IMapper _mapper;

        public GetLifeLimitItemRunningHourListRequestHandler(ISchoolManagementRepository<LifeLimitItemRunningHour> LifeLimitItemRunningHourRepository, IMapper mapper)
        {
            _LifeLimitItemRunningHourRepository = LifeLimitItemRunningHourRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LifeLimitItemRunningHourDto>> Handle(GetLifeLimitItemRunningHourListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<LifeLimitItemRunningHour> LifeLimitItemRunningHours = _LifeLimitItemRunningHourRepository.FilterWithInclude(x => (x.SlNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "LifeLimitItem", "MaintenanceCategory");
            var totalCount = LifeLimitItemRunningHours.Count();
            LifeLimitItemRunningHours = LifeLimitItemRunningHours.OrderByDescending(x => x.LifeLimitItemRunningHourId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var LifeLimitItemRunningHourDtos = _mapper.Map<List<LifeLimitItemRunningHourDto>>(LifeLimitItemRunningHours);
            var result = new PagedResult<LifeLimitItemRunningHourDto>(LifeLimitItemRunningHourDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
