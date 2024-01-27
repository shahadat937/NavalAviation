using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetAirCraftNameListRequestHandler : IRequestHandler<GetAirCraftNameListRequest, PagedResult<AirCraftNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AirCraftName> _AirCraftNameRepository;

        private readonly IMapper _mapper;

        public GetAirCraftNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AirCraftName> AirCraftNameRepository, IMapper mapper)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AirCraftNameDto>> Handle(GetAirCraftNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.AirCraftName> UTOfficerCategories = _AirCraftNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.AirCraftNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AirCraftNameDtos = _mapper.Map<List<AirCraftNameDto>>(UTOfficerCategories);
            var result = new PagedResult<AirCraftNameDto>(AirCraftNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
