using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetItemNameByIdRequestHandler : IRequestHandler<GetItemNameByIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository;


        public GetItemNameByIdRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetItemNameByIdRequest request, CancellationToken cancellationToken)
        {
            var ItemDetails = _ItemDetailRepository.FilterWithInclude(x => x.IsActive && x.ItemDetailId == request.ItemDetailId).ToList();
           // var name=ItemDetails.NameOfItem;
            //List<SelectedModel> selectModels = ItemDetails.Select(x => new SelectedModel 
            //{
            //    Text = x.PartNo,
            //    Value = x.ItemDetailId
            //}).ToList();
           // return ItemDetails;

            List<SelectedModel> selectModels = ItemDetails.Select(x => new SelectedModel
            {
                Text = x.ItemDetailId,
                Value = x.NameOfItem
            }).ToList();
            return selectModels;
        }
    }
}
