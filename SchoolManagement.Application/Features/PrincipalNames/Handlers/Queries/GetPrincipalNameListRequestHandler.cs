using SchoolManagement.Application.Features.PrincipalNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PrincipalName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Queries
{
    public class GetPrincipalNameListRequestHandler : IRequestHandler<GetPrincipalNameListRequest, PagedResult<PrincipalNameDto>>
    {

        private readonly ISchoolManagementRepository<PrincipalName> _PrincipalNameRepository;

        private readonly IMapper _mapper;

        public GetPrincipalNameListRequestHandler(ISchoolManagementRepository<PrincipalName> PrincipalNameRepository, IMapper mapper)
        {
            _PrincipalNameRepository = PrincipalNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PrincipalNameDto>> Handle(GetPrincipalNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<PrincipalName> UTOfficerCategories = _PrincipalNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.PrincipalNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PrincipalNameDtos = _mapper.Map<List<PrincipalNameDto>>(UTOfficerCategories);
            var result = new PagedResult<PrincipalNameDto>(PrincipalNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
