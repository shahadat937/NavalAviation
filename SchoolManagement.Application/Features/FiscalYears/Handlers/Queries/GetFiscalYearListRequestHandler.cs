using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.Features.FiscalYears.Requests.Queries;

namespace SchoolManagement.Application.Features.FiscalYears.Handlers.Queries
{
    public class GetFiscalYearListRequestHandler : IRequestHandler<GetFiscalYearListRequest, PagedResult<FiscalYearDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FiscalYear> _FiscalYearRepository;

        private readonly IMapper _mapper;

        public GetFiscalYearListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FiscalYear> FiscalYearRepository, IMapper mapper)
        {
            _FiscalYearRepository = FiscalYearRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FiscalYearDto>> Handle(GetFiscalYearListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.FiscalYear> FiscalYears = _FiscalYearRepository.FilterWithInclude(x => (x.FiscalYearName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = FiscalYears.Count();
            FiscalYears = FiscalYears.OrderByDescending(x => x.FiscalYearId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FiscalYearDtos = _mapper.Map<List<FiscalYearDto>>(FiscalYears);
            var result = new PagedResult<FiscalYearDto>(FiscalYearDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
