using SchoolManagement.Application.Features.ItemInspections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemInspection;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Queries
{
    public class GetItemInspectionListRequestHandler : IRequestHandler<GetItemInspectionListRequest, PagedResult<ItemInspectionDto>>
    {

        private readonly ISchoolManagementRepository<ItemInspection> _ItemInspectionRepository;

        private readonly IMapper _mapper;

        public GetItemInspectionListRequestHandler(ISchoolManagementRepository<ItemInspection> ItemInspectionRepository, IMapper mapper)
        {
            _ItemInspectionRepository = ItemInspectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemInspectionDto>> Handle(GetItemInspectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemInspection> UTOfficerCategories = _ItemInspectionRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ItemInspectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemInspectionDtos = _mapper.Map<List<ItemInspectionDto>>(UTOfficerCategories);
            var result = new PagedResult<ItemInspectionDto>(ItemInspectionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
