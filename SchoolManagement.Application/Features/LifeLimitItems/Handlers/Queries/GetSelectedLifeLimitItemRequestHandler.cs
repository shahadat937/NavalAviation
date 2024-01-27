using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.LifeLimitItems.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LifeLimitItems.Handlers.Queries
{
    public class GetSelectedLifeLimitItemRequestHandler : IRequestHandler<GetSelectedLifeLimitItemRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<LifeLimitItem> _LifeLimitItemRepository;


        public GetSelectedLifeLimitItemRequestHandler(ISchoolManagementRepository<LifeLimitItem> LifeLimitItemRepository)
        {
            _LifeLimitItemRepository = LifeLimitItemRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedLifeLimitItemRequest request, CancellationToken cancellationToken)
        {
            ICollection<LifeLimitItem> codeValues = await _LifeLimitItemRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.LifeLimitItemId
            }).ToList();
            return selectModels;
        }
    }
}
