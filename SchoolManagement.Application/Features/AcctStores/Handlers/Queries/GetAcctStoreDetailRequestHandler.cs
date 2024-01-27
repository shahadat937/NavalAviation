using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AcctStores;
using SchoolManagement.Application.Features.AcctStores.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AcctStores.Handlers.Queries
{
    public class GetAcctStoreDetailRequestHandler : IRequestHandler<GetAcctStoreDetailRequest, AcctStoreDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AcctStore> _AcctStoreRepository;
        public GetAcctStoreDetailRequestHandler(ISchoolManagementRepository<AcctStore> AcctStoreRepository, IMapper mapper)
        {
            _AcctStoreRepository = AcctStoreRepository;
            _mapper = mapper;
        }
        public async Task<AcctStoreDto> Handle(GetAcctStoreDetailRequest request, CancellationToken cancellationToken)
        {
            var AcctStore = await _AcctStoreRepository.Get(request.AcctStoreId);
            return _mapper.Map<AcctStoreDto>(AcctStore);
        }
    }
}
