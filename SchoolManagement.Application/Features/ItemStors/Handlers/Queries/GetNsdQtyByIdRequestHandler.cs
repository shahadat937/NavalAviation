using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetNsdQtyByIdRequestHandler : IRequestHandler<GetNsdQtyByIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;


        public GetNsdQtyByIdRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository)
        {
            _ItemStorRepository = ItemStorRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetNsdQtyByIdRequest request, CancellationToken cancellationToken)
        {
            var ItemStors = _ItemStorRepository.FilterWithInclude(x => x.IsActive && x.ItemStorId == request.ItemStorId).ToList();
           
            List<SelectedModel> selectModels = ItemStors.Select(x => new SelectedModel
            {
                Text = x.ItemStorId,
                Value = x.NsdQty
            }).ToList();
            return selectModels;
        }
    }
}
