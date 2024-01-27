using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Queries;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemStatuses.Handlers.Queries
{
    public class GetItemStatusListRequestHandler : IRequestHandler<GetItemStatusListRequest, PagedResult<ItemStatusDto>>
    {

        private readonly ISchoolManagementRepository<ItemStatus> _ItemStatusRepository;

        private readonly IMapper _mapper;

        public GetItemStatusListRequestHandler(ISchoolManagementRepository<ItemStatus> ItemStatusRepository, IMapper mapper)
        {
            _ItemStatusRepository = ItemStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemStatusDto>> Handle(GetItemStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ItemStatus> ItemStatuss = _ItemStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ItemStatuss.Count();
            ItemStatuss = ItemStatuss.OrderByDescending(x => x.ItemStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemStatusDtos = _mapper.Map<List<ItemStatusDto>>(ItemStatuss);
            var result = new PagedResult<ItemStatusDto>(ItemStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
