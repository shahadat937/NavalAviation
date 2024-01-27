using SchoolManagement.Application.Features.DemandTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DemandTypes.Handlers.Queries
{
    public class GetDemandTypeListRequestHandler : IRequestHandler<GetDemandTypeListRequest, PagedResult<DemandTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandType> _DemandTypeRepository;

        private readonly IMapper _mapper;

        public GetDemandTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DemandType> DemandTypeRepository, IMapper mapper)
        {
            _DemandTypeRepository = DemandTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandTypeDto>> Handle(GetDemandTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DemandType> UTOfficerCategories = _DemandTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DemandTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandTypeDtos = _mapper.Map<List<DemandTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<DemandTypeDto>(DemandTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
