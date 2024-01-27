using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries;

namespace SchoolManagement.Application.Features.ConditionOfItems.Handlers.Queries
{
    public class GetConditionOfItemListRequestHandler : IRequestHandler<GetConditionOfItemListRequest, PagedResult<ConditionOfItemDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ConditionOfItem> _ConditionOfItemRepository;

        private readonly IMapper _mapper;

        public GetConditionOfItemListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ConditionOfItem> ConditionOfItemRepository, IMapper mapper)
        {
            _ConditionOfItemRepository = ConditionOfItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ConditionOfItemDto>> Handle(GetConditionOfItemListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ConditionOfItem> ConditionOfItems = _ConditionOfItemRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ConditionOfItems.Count();
            ConditionOfItems = ConditionOfItems.OrderByDescending(x => x.ConditionOfItemId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ConditionOfItemDtos = _mapper.Map<List<ConditionOfItemDto>>(ConditionOfItems);
            var result = new PagedResult<ConditionOfItemDto>(ConditionOfItemDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
