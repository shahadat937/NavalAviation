using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetRequiredSparesForMaintenanceListRequestHandler : IRequestHandler<GetRequiredSparesForMaintenanceListRequest, PagedResult<RequiredSparesForMaintenanceDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RequiredSparesForMaintenance> _RequiredSparesForMaintenanceRepository;

        private readonly IMapper _mapper;

        public GetRequiredSparesForMaintenanceListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RequiredSparesForMaintenance> RequiredSparesForMaintenanceRepository, IMapper mapper)
        {
            _RequiredSparesForMaintenanceRepository = RequiredSparesForMaintenanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RequiredSparesForMaintenanceDto>> Handle(GetRequiredSparesForMaintenanceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.RequiredSparesForMaintenance> UTOfficerCategories = _RequiredSparesForMaintenanceRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.RequiredSparesForMaintenanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RequiredSparesForMaintenanceDtos = _mapper.Map<List<RequiredSparesForMaintenanceDto>>(UTOfficerCategories);
            var result = new PagedResult<RequiredSparesForMaintenanceDto>(RequiredSparesForMaintenanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
