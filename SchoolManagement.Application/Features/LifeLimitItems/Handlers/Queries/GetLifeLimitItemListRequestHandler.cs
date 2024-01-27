using SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Queries
{
    public class GetLifeLimitItemListRequestHandler : IRequestHandler<GetLifeLimitItemListRequest, PagedResult<LifeLimitItemDto>>
    {

        private readonly ISchoolManagementRepository<LifeLimitItem> _LifeLimitItemRepository;

        private readonly IMapper _mapper;

        public GetLifeLimitItemListRequestHandler(ISchoolManagementRepository<LifeLimitItem> LifeLimitItemRepository, IMapper mapper)
        {
            _LifeLimitItemRepository = LifeLimitItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LifeLimitItemDto>> Handle(GetLifeLimitItemListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<LifeLimitItem> LifeLimitItems = _LifeLimitItemRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = LifeLimitItems.Count();
            LifeLimitItems = LifeLimitItems.OrderByDescending(x => x.LifeLimitItemId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var LifeLimitItemDtos = _mapper.Map<List<LifeLimitItemDto>>(LifeLimitItems);
            var result = new PagedResult<LifeLimitItemDto>(LifeLimitItemDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
