using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStatuses.Handlers.Queries
{
    public class GetSelectedItemStatusRequestHandler : IRequestHandler<GetSelectedItemStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStatus> _ItemStatusRepository;


        public GetSelectedItemStatusRequestHandler(ISchoolManagementRepository<ItemStatus> ItemStatusRepository)
        {
            _ItemStatusRepository = ItemStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemStatus> codeValues = await _ItemStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ItemStatusId
            }).ToList();
            return selectModels;
        }
    }
}
