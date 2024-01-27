using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemCategories.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemCategories.Handlers.Queries
{
    public class GetSelectedItemCategoryRequestHandler : IRequestHandler<GetSelectedItemCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemCategory> _ItemCategoryRepository;


        public GetSelectedItemCategoryRequestHandler(ISchoolManagementRepository<ItemCategory> ItemCategoryRepository)
        {
            _ItemCategoryRepository = ItemCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemCategory> codeValues = await _ItemCategoryRepository.FilterAsync(x => x.SparesCategoryId == (request.spareCategoryId != 0 ? request.spareCategoryId : x.SparesCategoryId));
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ItemCategoryId
            }).ToList();
            return selectModels;


      //IQueryable<ItemCategory> codeValues = _ItemCategoryRepository.FilterWithInclude(x => x.IsActive == (request.Status == 1 ? true : false));
      //List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
      //{
      //  Text = x.Name,
      //  Value = x.ItemCategoryId
      //}).ToList();
      //return selectModels;
    }
    }
}
