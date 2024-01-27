using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.Features.ItemTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemTypes.Handlers.Queries
{
    public class GetItemTypeListRequestHandler : IRequestHandler<GetItemTypeListRequest, PagedResult<ItemTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemType> _ItemTypeRepository;

        private readonly IMapper _mapper;

        public GetItemTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemType> ItemTypeRepository, IMapper mapper)
        {
            _ItemTypeRepository = ItemTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemTypeDto>> Handle(GetItemTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ItemType> ItemTypes = _ItemTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ItemTypes.Count();
            ItemTypes = ItemTypes.OrderByDescending(x => x.ItemTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ItemTypeDtos = _mapper.Map<List<ItemTypeDto>>(ItemTypes);
            var result = new PagedResult<ItemTypeDto>(ItemTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
