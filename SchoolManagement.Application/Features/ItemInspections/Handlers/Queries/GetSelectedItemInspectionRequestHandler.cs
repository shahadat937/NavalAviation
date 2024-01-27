using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ItemInspections.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Queries
{
    public class GetSelectedItemInspectionRequestHandler : IRequestHandler<GetSelectedItemInspectionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ItemInspection> _ItemInspectionRepository;


        public GetSelectedItemInspectionRequestHandler(ISchoolManagementRepository<ItemInspection> ItemInspectionRepository)
        {
            _ItemInspectionRepository = ItemInspectionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedItemInspectionRequest request, CancellationToken cancellationToken)
        {
            ICollection<ItemInspection> codeValues = await _ItemInspectionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ItemInspectionId
            }).ToList();
            return selectModels;
        }
    }
}
