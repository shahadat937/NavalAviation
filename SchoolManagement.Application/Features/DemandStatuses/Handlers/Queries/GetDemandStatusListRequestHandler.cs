using SchoolManagement.Application.Features.DemandStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandStatus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandStatuses.Handlers.Queries
{
    public class GetDemandStatusListRequestHandler : IRequestHandler<GetDemandStatusListRequest, PagedResult<DemandStatusDto>>
    {

        private readonly ISchoolManagementRepository<DemandStatus> _DemandStatusRepository;

        private readonly IMapper _mapper;

        public GetDemandStatusListRequestHandler(ISchoolManagementRepository<DemandStatus> DemandStatusRepository, IMapper mapper)
        {
            _DemandStatusRepository = DemandStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandStatusDto>> Handle(GetDemandStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<DemandStatus> DemandStatuss = _DemandStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DemandStatuss.Count();
            DemandStatuss = DemandStatuss.OrderByDescending(x => x.DemandStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandStatusDtos = _mapper.Map<List<DemandStatusDto>>(DemandStatuss);
            var result = new PagedResult<DemandStatusDto>(DemandStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
