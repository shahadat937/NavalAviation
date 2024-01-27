using SchoolManagement.Application.Features.LocalAgents.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LocalAgent;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Queries
{
    public class GetLocalAgentListRequestHandler : IRequestHandler<GetLocalAgentListRequest, PagedResult<LocalAgentDto>>
    {

        private readonly ISchoolManagementRepository<LocalAgent> _LocalAgentRepository;

        private readonly IMapper _mapper;

        public GetLocalAgentListRequestHandler(ISchoolManagementRepository<LocalAgent> LocalAgentRepository, IMapper mapper)
        {
            _LocalAgentRepository = LocalAgentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LocalAgentDto>> Handle(GetLocalAgentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<LocalAgent> UTOfficerCategories = _LocalAgentRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.LocalAgentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var LocalAgentDtos = _mapper.Map<List<LocalAgentDto>>(UTOfficerCategories);
            var result = new PagedResult<LocalAgentDto>(LocalAgentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
