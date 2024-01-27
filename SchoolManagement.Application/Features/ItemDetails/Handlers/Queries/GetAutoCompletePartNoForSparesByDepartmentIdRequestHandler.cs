using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetAutoCompletePartNoForSparesByDepartmentIdRequestHandler : IRequestHandler<GetAutoCompletePartNoForSparesByDepartmentIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository; 
        public GetAutoCompletePartNoForSparesByDepartmentIdRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }
           
        public async Task<List<SelectedModel>> Handle(GetAutoCompletePartNoForSparesByDepartmentIdRequest request, CancellationToken cancellationToken)
        {
                ICollection<ItemDetail> partno = await _ItemDetailRepository.FilterAsync(x => x.IsActive  && x.PartNo.Contains(request.PartNo) && x.DepartmentNameId == request.DepartmentNameId);
                var selectModels = partno.Select(x => new SelectedModel
                { 
                    Text = x.PartNo,
                    Value = x.ItemDetailId
                }).ToList();
                return selectModels;
            }
      }
}
