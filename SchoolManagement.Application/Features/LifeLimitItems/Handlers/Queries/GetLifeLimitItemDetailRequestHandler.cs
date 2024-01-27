using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.LifeLimitItem;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Queries
{
    public class GetLifeLimitItemDetailRequestHandler : IRequestHandler<GetLifeLimitItemDetailRequest, LifeLimitItemDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<LifeLimitItem> _LifeLimitItemRepository;
        public GetLifeLimitItemDetailRequestHandler(ISchoolManagementRepository<LifeLimitItem> LifeLimitItemRepository, IMapper mapper)
        {
            _LifeLimitItemRepository = LifeLimitItemRepository;
            _mapper = mapper;
        }
        public async Task<LifeLimitItemDto> Handle(GetLifeLimitItemDetailRequest request, CancellationToken cancellationToken)
        {
            var LifeLimitItem = await _LifeLimitItemRepository.Get(request.LifeLimitItemId);
            return _mapper.Map<LifeLimitItemDto>(LifeLimitItem);
        }
    }
}
