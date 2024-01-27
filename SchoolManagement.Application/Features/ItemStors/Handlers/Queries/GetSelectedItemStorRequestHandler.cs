using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetSelectedItemStorRequestHandler : IRequestHandler<GetSelectedItemStorRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;


        public GetSelectedItemStorRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
        {
            _ItemStorRepository = ItemStorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemStorRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemStor> codeValues = await _ItemStorRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ItemSerNo,
                Value = x.ItemStorId
            }).ToList();
            return selectModels;
        }
    }
}
