using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Queries
{
    public class GetPreviousItemStoreDetailRequestHandler : IRequestHandler<GetPreviousItemStoreDetailRequest, PreviousItemStoreDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PreviousItemStore> _PreviousItemStoreRepository;
        public GetPreviousItemStoreDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PreviousItemStore> PreviousItemStoreRepository, IMapper mapper)
        {
            _PreviousItemStoreRepository = PreviousItemStoreRepository;
            _mapper = mapper;
        }
        public async Task<PreviousItemStoreDto> Handle(GetPreviousItemStoreDetailRequest request, CancellationToken cancellationToken)
        {
      //var PreviousItemStore = await _PreviousItemStoreRepository.Get(request.PreviousItemStoreId);
      //return _mapper.Map<PreviousItemStoreDto>(PreviousItemStore);
      var PreviousItemStore = _PreviousItemStoreRepository.FinedOneInclude(x => x.PreviousItemStoreId == request.PreviousItemStoreId, "DepartmentName", "Deno", "ItemDetail", "ToolsBoxName", "ToolsLocation", "ToolsType", "ItemCategory", "SparesCategory", "ServiceLifeType", "EndLifeType", "AcctStore", "OverhaulingType", "RetirementType");
      return _mapper.Map<PreviousItemStoreDto>(PreviousItemStore);
    }
    }
}
