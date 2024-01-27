using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.PreviousItemStore;
using SchoolManagement.Application.Features.PreviousItemStores.Requests.Queries;

namespace SchoolManagement.Application.Features.PreviousItemStores.Handlers.Queries
{
    public class GetPreviousItemStoreListByDepartmentIdRequestHandler : IRequestHandler<GetPreviousItemStoreListByDepartmentIdRequest, List<PreviousItemStoreDto>>
    {
        private readonly ISchoolManagementRepository<PreviousItemStore> _PreviousItemStoreRepository;

        private readonly IMapper _mapper;
        public GetPreviousItemStoreListByDepartmentIdRequestHandler(ISchoolManagementRepository<PreviousItemStore> PreviousItemStoreRepository, IMapper mapper)
        {
            _PreviousItemStoreRepository = PreviousItemStoreRepository;
            _mapper = mapper;
        }
         
        public async Task<List<PreviousItemStoreDto>> Handle(GetPreviousItemStoreListByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<PreviousItemStore> PreviousItemStores = _PreviousItemStoreRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "DepartmentName", "ItemDetail", "Deno", "ItemCategory", "AcctStore");

            var PreviousItemStoreDtos = _mapper.Map<List<PreviousItemStoreDto>>(PreviousItemStores);

            return PreviousItemStoreDtos;
        }

    }
}
