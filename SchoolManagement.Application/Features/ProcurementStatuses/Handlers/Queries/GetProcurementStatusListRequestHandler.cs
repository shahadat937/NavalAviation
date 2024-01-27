using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ProcurementStatus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Queries
{
    public class GetProcurementStatusListRequestHandler : IRequestHandler<GetProcurementStatusListRequest, PagedResult<ProcurementStatusDto>>
    {

        private readonly ISchoolManagementRepository<ProcurementStatus> _ProcurementStatusRepository;

        private readonly IMapper _mapper;

        public GetProcurementStatusListRequestHandler(ISchoolManagementRepository<ProcurementStatus> ProcurementStatusRepository, IMapper mapper)
        {
            _ProcurementStatusRepository = ProcurementStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProcurementStatusDto>> Handle(GetProcurementStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ProcurementStatus> UTOfficerCategories = _ProcurementStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ProcurementStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ProcurementStatusDtos = _mapper.Map<List<ProcurementStatusDto>>(UTOfficerCategories);
            var result = new PagedResult<ProcurementStatusDto>(ProcurementStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
