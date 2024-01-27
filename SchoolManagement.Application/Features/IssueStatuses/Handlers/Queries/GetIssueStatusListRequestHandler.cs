using SchoolManagement.Application.Features.IssueStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueStatus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.IssueStatuses.Handlers.Queries
{
    public class GetIssueStatusListRequestHandler : IRequestHandler<GetIssueStatusListRequest, PagedResult<IssueStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.IssueStatus> _IssueStatusRepository;

        private readonly IMapper _mapper;

        public GetIssueStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.IssueStatus> IssueStatusRepository, IMapper mapper)
        {
            _IssueStatusRepository = IssueStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<IssueStatusDto>> Handle(GetIssueStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.IssueStatus> UTOfficerCategories = _IssueStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.IssueStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var IssueStatusDtos = _mapper.Map<List<IssueStatusDto>>(UTOfficerCategories);
            var result = new PagedResult<IssueStatusDto>(IssueStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
