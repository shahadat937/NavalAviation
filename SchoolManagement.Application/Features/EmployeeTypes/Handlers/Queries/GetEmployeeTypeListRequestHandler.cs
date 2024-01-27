using AutoMapper;
using SchoolManagement.Application.DTOs.EmployeeType;
using SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.EmployeeTypes.Handlers.Queries
{
    public class GetEmployeeTypeListRequestHandler : IRequestHandler<GetEmployeeTypeListRequest, PagedResult<EmployeeTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EmployeeType> _EmployeeTypeRepository;

        private readonly IMapper _mapper;

        public GetEmployeeTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EmployeeType> EmployeeTypeRepository, IMapper mapper)
        {
            _EmployeeTypeRepository = EmployeeTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EmployeeTypeDto>> Handle(GetEmployeeTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.EmployeeType> EmployeeTypes = _EmployeeTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Religion");
            var totalCount = EmployeeTypes.Count();
            EmployeeTypes = EmployeeTypes.OrderByDescending(x => x.EmployeeTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EmployeeTypeDtos = _mapper.Map<List<EmployeeTypeDto>>(EmployeeTypes);
            var result = new PagedResult<EmployeeTypeDto>(EmployeeTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
