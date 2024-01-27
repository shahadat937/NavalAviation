using AutoMapper;
using SchoolManagement.Application.DTOs.Shop;
using SchoolManagement.Application.Features.Shops.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Shops.Handlers.Queries
{
    public class GetShopDetailRequestHandler : IRequestHandler<GetShopDetailRequest, ShopDto>
    {
       // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Shop> _ShopRepository;
        public GetShopDetailRequestHandler(ISchoolManagementRepository<Shop> ShopRepository, IMapper mapper)
        {
            _ShopRepository = ShopRepository;
            _mapper = mapper;
        }
        public async Task<ShopDto> Handle(GetShopDetailRequest request, CancellationToken cancellationToken)
        {
            var Shop = await _ShopRepository.Get(request.ShopId);
            return _mapper.Map<ShopDto>(Shop);
        }
    }
}
