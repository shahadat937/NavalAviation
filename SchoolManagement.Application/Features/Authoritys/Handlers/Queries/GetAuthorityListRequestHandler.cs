using SchoolManagement.Application.Features.Authoritys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Authority;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.Authoritys.Handlers.Queries
{
    public class GetAuthorityListRequestHandler : IRequestHandler<GetAuthorityListRequest, PagedResult<AuthorityDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Authority> _AuthorityRepository;

        private readonly IMapper _mapper;

        public GetAuthorityListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Authority> AuthorityRepository, IMapper mapper)
        {
            _AuthorityRepository = AuthorityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AuthorityDto>> Handle(GetAuthorityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Authority> UTOfficerCategories = _AuthorityRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.AuthorityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AuthorityDtos = _mapper.Map<List<AuthorityDto>>(UTOfficerCategories);
            var result = new PagedResult<AuthorityDto>(AuthorityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
