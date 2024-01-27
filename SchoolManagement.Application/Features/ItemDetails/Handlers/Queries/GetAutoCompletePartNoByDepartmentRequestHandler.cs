using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetAutoCompletePartNoByDepartmentRequestHandler : IRequestHandler<GetAutoCompletePartNoByDepartmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository; 
        public GetAutoCompletePartNoByDepartmentRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePartNoByDepartmentRequest request, CancellationToken cancellationToken)
        {
                ICollection<ItemDetail> itemDetails = await _ItemDetailRepository.FilterAsync(x => x.IsActive && x.PartNo.Contains(request.PartNo));
                var selectModels = itemDetails.Select(x => new SelectedModel
                { 
                    Text = x.PartNo,
                    Value = x.ItemDetailId
                }).ToList();
                return selectModels;
            }
      }
}
