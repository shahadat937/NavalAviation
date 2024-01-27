using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.DemandDocs;
using SchoolManagement.Application.Features.DemandDocs.Requests.Queries;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Queries
{
    public class GetDemandDocListRequestHandler : IRequestHandler<GetDemandDocListRequest, PagedResult<DemandDocDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandDoc> _DemandDocRepository;

        private readonly IMapper _mapper;

        public GetDemandDocListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandDoc> DemandDocRepository, IMapper mapper)
        {
            _DemandDocRepository = DemandDocRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandDocDto>> Handle(GetDemandDocListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DemandDoc> DemandDocs = _DemandDocRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DemandDocs.Count();
            DemandDocs = DemandDocs.OrderByDescending(x => x.DemandDocId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandDocDtos = _mapper.Map<List<DemandDocDto>>(DemandDocs);
            var result = new PagedResult<DemandDocDto>(DemandDocDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
