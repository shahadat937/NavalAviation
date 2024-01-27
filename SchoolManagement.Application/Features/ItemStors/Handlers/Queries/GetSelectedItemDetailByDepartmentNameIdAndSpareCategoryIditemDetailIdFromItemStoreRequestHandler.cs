using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIditemDetailIdFromItemStoreRequestHandler : IRequestHandler<GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIditemDetailIdFromItemStoreRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;

         
        public GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIditemDetailIdFromItemStoreRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
        {
            _ItemStorRepository = ItemStorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIditemDetailIdFromItemStoreRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _ItemStorRepository.FilterWithInclude(x => x.IsActive, "ItemDetail").Where(x=>x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId== request.SparesCategoryId && x.ItemDetailId ==request.ItemDetailId && x.AvailableQty != 0);
            var selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemDetail.NameOfItem,
                Value = x.ItemDetailId
            }).Distinct();
            return selectModels.ToList();
        }
    }
}
