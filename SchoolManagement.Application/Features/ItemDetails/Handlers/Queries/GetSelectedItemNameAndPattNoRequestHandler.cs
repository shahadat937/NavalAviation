using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetSelectedItemNameAndPattNoRequestHandler : IRequestHandler<GetSelectedItemNameAndPattNoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository;


        public GetSelectedItemNameAndPattNoRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
      _ItemDetailRepository = ItemDetailRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemNameAndPattNoRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemDetail> codeValues = await _ItemDetailRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.NameOfItem +"-"+ x.PartNo,
                Value = x.ItemDetailId
            }).ToList();
            return selectModels;
        }
    }
}
