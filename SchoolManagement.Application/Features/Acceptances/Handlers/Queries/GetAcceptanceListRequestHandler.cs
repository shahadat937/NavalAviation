using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetAcceptanceListRequestHandler : IRequestHandler<GetAcceptanceListRequest, PagedResult<AcceptanceDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Acceptance> _AcceptanceRepository;

        private readonly IMapper _mapper;

        public GetAcceptanceListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Acceptance> AcceptanceRepository, IMapper mapper)
        {
            _AcceptanceRepository = AcceptanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AcceptanceDto>> Handle(GetAcceptanceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
           // IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Demand", "DepartmentName", "ItemDetail", "LocalAgent", "PartOfShipment", "PrincipalName", "ProcurementStatus").Where(x => x.SparesCategoryId == request.SparesCategoryId && x.ProcurementCompleteStatus == 0);
            IQueryable<SchoolManagement.Domain.Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "ItemDetail", "Demand").Where(x => x.SparesCategoryId == request.SparesCategoryId);
            var totalCount = Acceptances.Count();
            Acceptances = Acceptances.OrderByDescending(x => x.AcceptanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
            var AcceptanceDtos = _mapper.Map<List<AcceptanceDto>>(Acceptances);
            var result = new PagedResult<AcceptanceDto>(AcceptanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
