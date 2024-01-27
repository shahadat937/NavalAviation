using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.Features.ItemTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemTypes.Handlers.Queries
{
    public class GetItemTypeDetailRequestHandler : IRequestHandler<GetItemTypeDetailRequest, ItemTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ItemType> _ItemTypeRepository;
        public GetItemTypeDetailRequestHandler(ISchoolManagementRepository<ItemType> ItemTypeRepository, IMapper mapper)
        {
            _ItemTypeRepository = ItemTypeRepository;
            _mapper = mapper;
        }
        public async Task<ItemTypeDto> Handle(GetItemTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemType = await _ItemTypeRepository.Get(request.ItemTypeId);
            return _mapper.Map<ItemTypeDto>(ItemType);
        }
    }
}
