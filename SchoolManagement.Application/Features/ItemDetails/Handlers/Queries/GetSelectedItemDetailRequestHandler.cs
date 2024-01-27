using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemDetails.Handlers.Queries
{
    public class GetSelectedItemDetailRequestHandler : IRequestHandler<GetSelectedItemDetailRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemDetail> _ItemDetailRepository;


        public GetSelectedItemDetailRequestHandler(ISchoolManagementRepository<ItemDetail> ItemDetailRepository)
        {
            _ItemDetailRepository = ItemDetailRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemDetailRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemDetail> codeValues = await _ItemDetailRepository.FilterAsync(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == request.SparesCategoryId && x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.PartNo,
                Value = x.ItemDetailId
            }).ToList();
            return selectModels;
        }
    }
}
