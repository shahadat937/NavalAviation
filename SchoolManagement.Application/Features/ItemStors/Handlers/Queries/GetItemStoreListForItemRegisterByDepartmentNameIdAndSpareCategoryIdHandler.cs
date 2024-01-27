using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetItemStoreListForItemRegisterByDepartmentNameIdAndSpareCategoryIdHandler : IRequestHandler<GetItemStoreListForItemRegisterByDepartmentNameIdAndSpareCategoryIdRequest, List<ItemStorDto>>
    {
          
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;

        private readonly IMapper _mapper;
         
        public GetItemStoreListForItemRegisterByDepartmentNameIdAndSpareCategoryIdHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository, IMapper mapper)
        {
            _ItemStorRepository = ItemStorRepository; 
            _mapper = mapper;
        }

        public async Task<List<ItemStorDto>> Handle(GetItemStoreListForItemRegisterByDepartmentNameIdAndSpareCategoryIdRequest request, CancellationToken cancellationToken)
        {
            var  ItemStors = _ItemStorRepository.FilterWithInclude(x=>x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId  && x.AvailableQty !=0, "ItemDetail", "Deno", "AcctStore");

            var ItemStorDtos = _mapper.Map<List<ItemStorDto>>(ItemStors);

            return ItemStorDtos; 
        }
    }
}
