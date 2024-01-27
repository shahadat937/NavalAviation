using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemTypes.Handlers.Queries
{
    public class GetSelectedItemTypeRequestHandler : IRequestHandler<GetSelectedItemTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemType> _ItemTypeRepository;


        public GetSelectedItemTypeRequestHandler(ISchoolManagementRepository<ItemType> ItemTypeRepository)
        {
            _ItemTypeRepository = ItemTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemType> codeValues = await _ItemTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ItemTypeId
            }).ToList();
            return selectModels;
        }
    }
}
