using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetSelectedItemDetailForStockTransferNsdRequestHandler : IRequestHandler<GetSelectedItemDetailForStockTransferNsdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;


        public GetSelectedItemDetailForStockTransferNsdRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
        {
            _ItemStorRepository = ItemStorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemDetailForStockTransferNsdRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _ItemStorRepository.FilterWithInclude(x => x.IsActive, "ItemDetail").Where(x=>x.DepartmentNameId==request.DepartmentNameId && x.ToolsLocationId==8);
            var selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemDetail.NameOfItem+'-'+x.ItemDetail.PartNo,
                Value = x.ItemStorId
            }).Distinct();
            return selectModels.ToList();
        }
    }
}
