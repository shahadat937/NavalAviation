using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Store;
using SchoolManagement.Application.Features.Stores.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Stores.Handlers.Queries
{
    public class GetStoreDetailRequestHandler : IRequestHandler<GetStoreDetailRequest, StoreDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Store> _StoreRepository;
        public GetStoreDetailRequestHandler(ISchoolManagementRepository<Store> StoreRepository, IMapper mapper)
        {
            _StoreRepository = StoreRepository;
            _mapper = mapper;
        }
        public async Task<StoreDto> Handle(GetStoreDetailRequest request, CancellationToken cancellationToken)
        {
            var Store = await _StoreRepository.Get(request.StoreId);
            return _mapper.Map<StoreDto>(Store);
        }
    }
}
