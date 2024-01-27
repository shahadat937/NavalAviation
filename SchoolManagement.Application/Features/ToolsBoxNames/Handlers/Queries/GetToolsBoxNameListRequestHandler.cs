using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Queries
{
    public class GetToolsBoxNameListRequestHandler : IRequestHandler<GetToolsBoxNameListRequest, PagedResult<ToolsBoxNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ToolsBoxName> _ToolsBoxNameRepository;

        private readonly IMapper _mapper;

        public GetToolsBoxNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ToolsBoxName> ToolsBoxNameRepository, IMapper mapper)
        {
            _ToolsBoxNameRepository = ToolsBoxNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ToolsBoxNameDto>> Handle(GetToolsBoxNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ToolsBoxName> ToolsBoxNames = _ToolsBoxNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ToolsBoxNames.Count();
            ToolsBoxNames = ToolsBoxNames.OrderByDescending(x => x.ToolsBoxNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ToolsBoxNameDtos = _mapper.Map<List<ToolsBoxNameDto>>(ToolsBoxNames);
            var result = new PagedResult<ToolsBoxNameDto>(ToolsBoxNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
