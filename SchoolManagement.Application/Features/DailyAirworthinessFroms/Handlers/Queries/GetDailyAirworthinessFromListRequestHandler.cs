using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Queries
{
    public class GetDailyAirworthinessFromListRequestHandler : IRequestHandler<GetDailyAirworthinessFromListRequest, PagedResult<DailyAirworthinessFromDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFrom> _DailyAirworthinessFromRepository;

        private readonly IMapper _mapper;

        public GetDailyAirworthinessFromListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFrom> DailyAirworthinessFromRepository, IMapper mapper)
        {
            _DailyAirworthinessFromRepository = DailyAirworthinessFromRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DailyAirworthinessFromDto>> Handle(GetDailyAirworthinessFromListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DailyAirworthinessFrom> UTOfficerCategories = _DailyAirworthinessFromRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DailyAirworthinessFromId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DailyAirworthinessFromDtos = _mapper.Map<List<DailyAirworthinessFromDto>>(UTOfficerCategories);
            var result = new PagedResult<DailyAirworthinessFromDto>(DailyAirworthinessFromDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
