using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ToolsTypes;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Queries
{
    public class GetToolsTypeListRequestHandler : IRequestHandler<GetToolsTypeListRequest, PagedResult<ToolsTypeDto>>
    {

        private readonly ISchoolManagementRepository<ToolsType> _ToolsTypeRepository;

        private readonly IMapper _mapper;

        public GetToolsTypeListRequestHandler(ISchoolManagementRepository<ToolsType> ToolsTypeRepository, IMapper mapper)
        {
            _ToolsTypeRepository = ToolsTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ToolsTypeDto>> Handle(GetToolsTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ToolsType> ToolsTypes = _ToolsTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ToolsTypes.Count();
            ToolsTypes = ToolsTypes.OrderByDescending(x => x.ToolsTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ToolsTypeDtos = _mapper.Map<List<ToolsTypeDto>>(ToolsTypes);
            var result = new PagedResult<ToolsTypeDto>(ToolsTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
