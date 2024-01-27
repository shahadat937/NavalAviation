using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemDetailByDepartmentIdRequestHandler : IRequestHandler<GetItemDetailByDepartmentIdRequest, List<ItemDetailDto>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository;

        private readonly IMapper _mapper;
        public GetItemDetailByDepartmentIdRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository, IMapper mapper)
        {
            _ItemDetailRepository = ItemDetailRepository;
            _mapper = mapper;
        }
         
        public async Task<List<ItemDetailDto>> Handle(GetItemDetailByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ItemDetail> ItemDetails = _ItemDetailRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId !=2, "Trade");

            var ItemDetailDtos = _mapper.Map<List<ItemDetailDto>>(ItemDetails);

            return ItemDetailDtos;
        }

    }
}
