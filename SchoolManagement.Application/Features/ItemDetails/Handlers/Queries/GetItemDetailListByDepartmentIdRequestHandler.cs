using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemDetailListByDepartmentIdRequestHandler : IRequestHandler<GetItemDetailListByDepartmentIdRequest, List<ItemDetailDto>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository;

        private readonly IMapper _mapper;
        public GetItemDetailListByDepartmentIdRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository, IMapper mapper)
        {
            _ItemDetailRepository = ItemDetailRepository;
            _mapper = mapper;
        }
         
        public async Task<List<ItemDetailDto>> Handle(GetItemDetailListByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ItemDetail> ItemDetails = _ItemDetailRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId==2, "DepartmentName");

            var ItemDetailDtos = _mapper.Map<List<ItemDetailDto>>(ItemDetails);

            return ItemDetailDtos;
        }

    }
}
