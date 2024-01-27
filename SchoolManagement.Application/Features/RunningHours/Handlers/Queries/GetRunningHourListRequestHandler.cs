using SchoolManagement.Application.Features.RunningHours.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RunningHour;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RunningHours.Handlers.Queries
{
    public class GetRunningHourListRequestHandler : IRequestHandler<GetRunningHourListRequest, PagedResult<RunningHourDto>>
    {

        private readonly ISchoolManagementRepository<RunningHour> _RunningHourRepository;

        private readonly IMapper _mapper;

        public GetRunningHourListRequestHandler(ISchoolManagementRepository<RunningHour> RunningHourRepository, IMapper mapper)
        {
            _RunningHourRepository = RunningHourRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RunningHourDto>> Handle(GetRunningHourListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<RunningHour> UTOfficerCategories = _RunningHourRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "AirCraftName", "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.RunningHourId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RunningHourDtos = _mapper.Map<List<RunningHourDto>>(UTOfficerCategories);
            var result = new PagedResult<RunningHourDto>(RunningHourDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
