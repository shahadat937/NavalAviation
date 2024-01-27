using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ConditionOfItems.Handlers.Queries
{
    public class GetSelectedConditionOfItemRequestHandler : IRequestHandler<GetSelectedConditionOfItemRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ConditionOfItem> _ConditionOfItemRepository;


        public GetSelectedConditionOfItemRequestHandler(ISchoolManagementRepository<ConditionOfItem> ConditionOfItemRepository)
        {
            _ConditionOfItemRepository = ConditionOfItemRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedConditionOfItemRequest request, CancellationToken cancellationToken)
        {
            ICollection<ConditionOfItem> codeValues = await _ConditionOfItemRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ConditionOfItemId
            }).ToList();
            return selectModels;
        }
    }
}
