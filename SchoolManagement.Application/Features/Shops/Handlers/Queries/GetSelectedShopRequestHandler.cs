using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Shops.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Shops.Handlers.Queries
{
    public class GetSelectedShopRequestHandler : IRequestHandler<GetSelectedShopRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Shop> _ShopRepository;


        public GetSelectedShopRequestHandler(ISchoolManagementRepository<Shop> ShopRepository)
        {
            _ShopRepository = ShopRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedShopRequest request, CancellationToken cancellationToken)
        {
            ICollection<Shop> codeValues = await _ShopRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ShopId
            }).ToList();
            return selectModels;
        }
    }
}
