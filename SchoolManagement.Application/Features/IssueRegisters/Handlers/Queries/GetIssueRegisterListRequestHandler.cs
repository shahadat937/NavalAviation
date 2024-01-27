using SchoolManagement.Application.Features.IssueRegisters.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueRegister;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Queries
{
    public class GetIssueRegisterListRequestHandler : IRequestHandler<GetIssueRegisterListRequest, PagedResult<IssueRegisterDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.IssueRegister> _IssueRegisterRepository;

        private readonly IMapper _mapper;

        public GetIssueRegisterListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.IssueRegister> IssueRegisterRepository, IMapper mapper)
        {
            _IssueRegisterRepository = IssueRegisterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<IssueRegisterDto>> Handle(GetIssueRegisterListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.IssueRegister> UTOfficerCategories = _IssueRegisterRepository.FilterWithInclude(x => (x.IssuedTo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "TrainingCrew", "ItemDetail");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.IssueRegisterId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var IssueRegisterDtos = _mapper.Map<List<IssueRegisterDto>>(UTOfficerCategories);
            var result = new PagedResult<IssueRegisterDto>(IssueRegisterDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
