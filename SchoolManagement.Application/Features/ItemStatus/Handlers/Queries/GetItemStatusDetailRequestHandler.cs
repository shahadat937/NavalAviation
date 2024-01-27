using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemStatuses;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemStatuses.Handlers.Queries
{
    public class GetItemStatusDetailRequestHandler : IRequestHandler<GetItemStatusDetailRequest, ItemStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ItemStatus> _ItemStatusRepository;
        public GetItemStatusDetailRequestHandler(ISchoolManagementRepository<ItemStatus> ItemStatusRepository, IMapper mapper)
        {
            _ItemStatusRepository = ItemStatusRepository;
            _mapper = mapper;
        }
        public async Task<ItemStatusDto> Handle(GetItemStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemStatus = await _ItemStatusRepository.Get(request.ItemStatusId);
            return _mapper.Map<ItemStatusDto>(ItemStatus);
        }
    }
}
