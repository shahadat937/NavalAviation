using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetSelectedItemDetailForSurveyRequestHandler : IRequestHandler<GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIdFromItemStoreRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;


        public GetSelectedItemDetailForSurveyRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
        {
            _ItemStorRepository = ItemStorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemDetailByDepartmentNameIdAndSpareCategoryIdFromItemStoreRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _ItemStorRepository.FilterWithInclude(x => x.IsActive, "ItemDetail").Where(x=>x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId== request.SparesCategoryId);
            var selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemDetail.PartNo,
                Value = x.ItemDetailId
            }).Distinct();
            return selectModels.ToList();
        }
    }
}
