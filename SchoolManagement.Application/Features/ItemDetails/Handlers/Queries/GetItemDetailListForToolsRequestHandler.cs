using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemDetailListForToolsRequestHandler : IRequestHandler<GetItemDetailListForToolsRequest, PagedResult<ItemDetailDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemDetail> _ItemDetailRepository;

        private readonly IMapper _mapper;

        public GetItemDetailListForToolsRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemDetail> ItemDetailRepository, IMapper mapper)
        {
            _ItemDetailRepository = ItemDetailRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemDetailDto>> Handle(GetItemDetailListForToolsRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemDetail> UTOfficerCategories = _ItemDetailRepository.FilterWithInclude(x => (x.PartNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ItemDetailId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=>x.SparesCategoryId==request.SparesCategoryId);

            var ItemDetailDtos = _mapper.Map<List<ItemDetailDto>>(UTOfficerCategories);
            var result = new PagedResult<ItemDetailDto>(ItemDetailDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
