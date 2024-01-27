using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetAutoCompletePartNoRequestHandler : IRequestHandler<GetAutoCompletePartNoRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository; 
        public GetAutoCompletePartNoRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePartNoRequest request, CancellationToken cancellationToken)
        {
                ICollection<ItemDetail> traineeBioDataGeneralInfos = await _ItemDetailRepository.FilterAsync(x => x.IsActive && x.PartNo.Contains(request.PartNo));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.PartNo,
                    Value = x.ItemDetailId
                }).ToList();
                return selectModels;
            }
      }
}
