using SchoolManagement.Application.Features.RetirementTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RetirementType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RetirementTypes.Handlers.Queries
{
    public class GetRetirementTypeListRequestHandler : IRequestHandler<GetRetirementTypeListRequest, PagedResult<RetirementTypeDto>>
    {

        private readonly ISchoolManagementRepository<RetirementType> _RetirementTypeRepository;

        private readonly IMapper _mapper;

        public GetRetirementTypeListRequestHandler(ISchoolManagementRepository<RetirementType> RetirementTypeRepository, IMapper mapper)
        {
            _RetirementTypeRepository = RetirementTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RetirementTypeDto>> Handle(GetRetirementTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<RetirementType> UTOfficerCategories = _RetirementTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.RetirementTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RetirementTypeDtos = _mapper.Map<List<RetirementTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<RetirementTypeDto>(RetirementTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
