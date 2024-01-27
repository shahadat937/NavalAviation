using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Queries
{
    public class GetToolsLocationListRequestHandler : IRequestHandler<GetToolsLocationListRequest, PagedResult<ToolsLocationDto>>
    {

        private readonly ISchoolManagementRepository<ToolsLocation> _ToolsLocationRepository;

        private readonly IMapper _mapper;

        public GetToolsLocationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ToolsLocation> ToolsLocationRepository, IMapper mapper)
        {
            _ToolsLocationRepository = ToolsLocationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ToolsLocationDto>> Handle(GetToolsLocationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ToolsLocation> UTOfficerCategories = _ToolsLocationRepository.FilterWithInclude(x => (x.ToolsLocationName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ToolsLocationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ToolsLocationDtos = _mapper.Map<List<ToolsLocationDto>>(UTOfficerCategories);
            var result = new PagedResult<ToolsLocationDto>(ToolsLocationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
