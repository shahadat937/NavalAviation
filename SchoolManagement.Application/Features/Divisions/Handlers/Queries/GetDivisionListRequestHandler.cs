using AutoMapper;
using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.Features.Divisions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Divisions.Handlers.Queries
{
    public class GetDivisionListRequestHandler : IRequestHandler<GetDivisionListRequest, PagedResult<DivisionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Division> _DivisionRepository;

        private readonly IMapper _mapper;

        public GetDivisionListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Division> DivisionRepository, IMapper mapper)
        {
            _DivisionRepository = DivisionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DivisionDto>> Handle(GetDivisionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Division> Divisions = _DivisionRepository.FilterWithInclude(x => (x.DivisionName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Divisions.Count();
            Divisions = Divisions.OrderByDescending(x => x.DivisionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DivisionDtos = _mapper.Map<List<DivisionDto>>(Divisions);
            var result = new PagedResult<DivisionDto>(DivisionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
