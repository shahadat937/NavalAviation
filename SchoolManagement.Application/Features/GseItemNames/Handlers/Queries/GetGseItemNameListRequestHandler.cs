using SchoolManagement.Application.Features.GseItemNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Queries
{
    public class GetGseItemNameListRequestHandler : IRequestHandler<GetGseItemNameListRequest, PagedResult<GseItemNameDto>>
    {

        private readonly ISchoolManagementRepository<GseItemName> _GseItemNameRepository;

        private readonly IMapper _mapper;

        public GetGseItemNameListRequestHandler(ISchoolManagementRepository<GseItemName> GseItemNameRepository, IMapper mapper)
        {
            _GseItemNameRepository = GseItemNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GseItemNameDto>> Handle(GetGseItemNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<GseItemName> GseItemNames = _GseItemNameRepository.FilterWithInclude(x => (x.ItemName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = GseItemNames.Count();
            GseItemNames = GseItemNames.OrderByDescending(x => x.GseItemNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GseItemNameDtos = _mapper.Map<List<GseItemNameDto>>(GseItemNames);
            var result = new PagedResult<GseItemNameDto>(GseItemNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
