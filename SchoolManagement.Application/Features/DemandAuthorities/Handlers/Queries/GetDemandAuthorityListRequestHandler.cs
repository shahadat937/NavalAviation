using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators; 
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries;
using SchoolManagement.Application.DTOs.DemandAuthority;

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Queries
{
    public class GetDemandAuthorityListRequestHandler : IRequestHandler<GetDemandAuthorityListRequest, PagedResult<DemandAuthorityDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandAuthority> _DemandAuthorityRepository;

        private readonly IMapper _mapper;

        public GetDemandAuthorityListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandAuthority> DemandAuthorityRepository, IMapper mapper)
        {
            _DemandAuthorityRepository = DemandAuthorityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandAuthorityDto>> Handle(GetDemandAuthorityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DemandAuthority> DemandAuthoritys = _DemandAuthorityRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DemandAuthoritys.Count();
            DemandAuthoritys = DemandAuthoritys.OrderByDescending(x => x.DemandAuthorityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandAuthorityDtos = _mapper.Map<List<DemandAuthorityDto>>(DemandAuthoritys);
            var result = new PagedResult<DemandAuthorityDto>(DemandAuthorityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
