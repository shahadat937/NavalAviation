using SchoolManagement.Application.Features.DepartmentNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DepartmentNames.Handlers.Queries
{
    public class GetDepartmentNameListRequestHandler : IRequestHandler<GetDepartmentNameListRequest, PagedResult<DepartmentNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DepartmentName> _DepartmentNameRepository;

        private readonly IMapper _mapper;

        public GetDepartmentNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DepartmentName> DepartmentNameRepository, IMapper mapper)
        {
            _DepartmentNameRepository = DepartmentNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DepartmentNameDto>> Handle(GetDepartmentNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DepartmentName> UTOfficerCategories = _DepartmentNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DepartmentNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DepartmentNameDtos = _mapper.Map<List<DepartmentNameDto>>(UTOfficerCategories);
            var result = new PagedResult<DepartmentNameDto>(DepartmentNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
