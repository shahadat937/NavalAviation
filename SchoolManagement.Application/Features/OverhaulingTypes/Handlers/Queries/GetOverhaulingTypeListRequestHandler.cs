using SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OverhaulingType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Handlers.Queries
{
    public class GetOverhaulingTypeListRequestHandler : IRequestHandler<GetOverhaulingTypeListRequest, PagedResult<OverhaulingTypeDto>>
    {

        private readonly ISchoolManagementRepository<OverhaulingType> _OverhaulingTypeRepository;

        private readonly IMapper _mapper;

        public GetOverhaulingTypeListRequestHandler(ISchoolManagementRepository<OverhaulingType> OverhaulingTypeRepository, IMapper mapper)
        {
            _OverhaulingTypeRepository = OverhaulingTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OverhaulingTypeDto>> Handle(GetOverhaulingTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<OverhaulingType> UTOfficerCategories = _OverhaulingTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.OverhaulingTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OverhaulingTypeDtos = _mapper.Map<List<OverhaulingTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<OverhaulingTypeDto>(OverhaulingTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
