using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemCategorys;
using SchoolManagement.Application.Features.ItemCategories.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Queries
{
    public class GetItemCategoryDetailRequestHandler : IRequestHandler<GetItemCategoryDetailRequest, ItemCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemCategory> _ItemCategoryRepository;
        public GetItemCategoryDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemCategory> ItemCategoryRepository, IMapper mapper)
        {
            _ItemCategoryRepository = ItemCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ItemCategoryDto> Handle(GetItemCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemCategory = await _ItemCategoryRepository.Get(request.ItemCategoryId);
            return _mapper.Map<ItemCategoryDto>(ItemCategory);
        }
    }
}
