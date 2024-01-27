using SchoolManagement.Application.Features.AccountTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.AccountTypes.Handlers.Queries
{
    public class GetAccountTypeListRequestHandler : IRequestHandler<GetAccountTypeListRequest, PagedResult<AccountTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AccountType> _AccountTypeRepository;

        private readonly IMapper _mapper;

        public GetAccountTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AccountType> AccountTypeRepository, IMapper mapper)
        {
            _AccountTypeRepository = AccountTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AccountTypeDto>> Handle(GetAccountTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.AccountType> UTOfficerCategories = _AccountTypeRepository.FilterWithInclude(x => (x.AccoutType.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.AccountTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AccountTypeDtos = _mapper.Map<List<AccountTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<AccountTypeDto>(AccountTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
