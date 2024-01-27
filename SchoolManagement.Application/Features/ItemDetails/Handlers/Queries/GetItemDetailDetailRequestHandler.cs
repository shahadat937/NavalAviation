using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemDetailDetailRequestHandler : IRequestHandler<GetItemDetailDetailRequest, ItemDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemDetail> _ItemDetailRepository;
        public GetItemDetailDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemDetail> ItemDetailRepository, IMapper mapper)
        {
            _ItemDetailRepository = ItemDetailRepository;
            _mapper = mapper;
        }
        public async Task<ItemDetailDto> Handle(GetItemDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemDetail = await _ItemDetailRepository.Get(request.ItemDetailId);
            return _mapper.Map<ItemDetailDto>(ItemDetail);
        }
    }
}
