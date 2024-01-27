using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries;

namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Queries
{
    public class GetMeaWorkShopDetailRequestHandler : IRequestHandler<GetMeaWorkShopDetailRequest, MeaWorkShopDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaWorkShop> _MeaWorkShopRepository;
        public GetMeaWorkShopDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaWorkShop> MeaWorkShopRepository, IMapper mapper)
        {
            _MeaWorkShopRepository = MeaWorkShopRepository;
            _mapper = mapper;
        }
        public async Task<MeaWorkShopDto> Handle(GetMeaWorkShopDetailRequest request, CancellationToken cancellationToken)
        {
            var MeaWorkShop = await _MeaWorkShopRepository.Get(request.MeaWorkShopId);
            return _mapper.Map<MeaWorkShopDto>(MeaWorkShop);
        }
    }
}
