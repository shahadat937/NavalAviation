using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ConditionOfItems;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ConditionOfItems.Handlers.Queries
{
    public class GetConditionOfItemDetailRequestHandler : IRequestHandler<GetConditionOfItemDetailRequest, ConditionOfItemDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ConditionOfItem> _ConditionOfItemRepository;
        public GetConditionOfItemDetailRequestHandler(ISchoolManagementRepository<ConditionOfItem> ConditionOfItemRepository, IMapper mapper)
        {
            _ConditionOfItemRepository = ConditionOfItemRepository;
            _mapper = mapper;
        }
        public async Task<ConditionOfItemDto> Handle(GetConditionOfItemDetailRequest request, CancellationToken cancellationToken)
        {
            var ConditionOfItem = await _ConditionOfItemRepository.Get(request.ConditionOfItemId);
            return _mapper.Map<ConditionOfItemDto>(ConditionOfItem);
        }
    }
}
