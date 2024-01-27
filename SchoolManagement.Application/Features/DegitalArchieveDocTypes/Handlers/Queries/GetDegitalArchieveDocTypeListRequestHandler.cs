using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Queries
{
    public class GetDegitalArchieveDocTypeListRequestHandler : IRequestHandler<GetDegitalArchieveDocTypeListRequest, PagedResult<DegitalArchieveDocTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieveDocType> _DegitalArchieveDocTypeRepository;

        private readonly IMapper _mapper;

        public GetDegitalArchieveDocTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieveDocType> DegitalArchieveDocTypeRepository, IMapper mapper)
        {
            _DegitalArchieveDocTypeRepository = DegitalArchieveDocTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DegitalArchieveDocTypeDto>> Handle(GetDegitalArchieveDocTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DegitalArchieveDocType> UTOfficerCategories = _DegitalArchieveDocTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DegitalArchieveDocTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DegitalArchieveDocTypeDtos = _mapper.Map<List<DegitalArchieveDocTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<DegitalArchieveDocTypeDto>(DegitalArchieveDocTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
