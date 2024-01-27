using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemCategoryTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemCategoryTypes.Handlers.Queries
{
    public class GetSelectedItemCategoryTypeRequestHandler : IRequestHandler<GetSelectedItemCategoryTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemCategoryType> _ItemCategoryTypeRepository;


        public GetSelectedItemCategoryTypeRequestHandler(ISchoolManagementRepository<ItemCategoryType> ItemCategoryTypeRepository)
        {
            _ItemCategoryTypeRepository = ItemCategoryTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemCategoryTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemCategoryType> codeValues = await _ItemCategoryTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ItemCategoryTypeId
            }).ToList();
            return selectModels;
        }
    }
}
