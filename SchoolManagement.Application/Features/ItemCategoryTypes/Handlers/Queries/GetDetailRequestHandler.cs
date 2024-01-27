using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemCategoryType;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Queries
{
    public class GetItemCategoryTypeDetailRequestHandler : IRequestHandler<GetItemCategoryTypeDetailRequest, ItemCategoryTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemCategoryType> _ItemCategoryTypeRepository;
        public GetItemCategoryTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemCategoryType> ItemCategoryTypeRepository, IMapper mapper)
        {
            _ItemCategoryTypeRepository = ItemCategoryTypeRepository;
            _mapper = mapper;
        }
        public async Task<ItemCategoryTypeDto> Handle(GetItemCategoryTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemCategoryType = await _ItemCategoryTypeRepository.Get(request.ItemCategoryTypeId);
            return _mapper.Map<ItemCategoryTypeDto>(ItemCategoryType);
        }
    }
}
