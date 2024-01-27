using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;
using SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Queries;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Handlers.Queries
{
    public class GetDemandCompleteStatusListRequestHandler : IRequestHandler<GetDemandCompleteStatusListRequest, PagedResult<DemandCompleteStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandCompleteStatus> _DemandCompleteStatusRepository;

        private readonly IMapper _mapper;

        public GetDemandCompleteStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandCompleteStatus> DemandCompleteStatusRepository, IMapper mapper)
        {
            _DemandCompleteStatusRepository = DemandCompleteStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandCompleteStatusDto>> Handle(GetDemandCompleteStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DemandCompleteStatus> DemandCompleteStatuss = _DemandCompleteStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DemandCompleteStatuss.Count();
            DemandCompleteStatuss = DemandCompleteStatuss.OrderByDescending(x => x.DemandCompleteStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandCompleteStatusDtos = _mapper.Map<List<DemandCompleteStatusDto>>(DemandCompleteStatuss);
            var result = new PagedResult<DemandCompleteStatusDto>(DemandCompleteStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
