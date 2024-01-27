using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Queries
{
    public class GetSelectedEquipmentNameRequestHandler : IRequestHandler<GetSelectedEquipmentNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<EquipmentName> _EquipmentNameRepository;


        public GetSelectedEquipmentNameRequestHandler(ISchoolManagementRepository<EquipmentName> EquipmentNameRepository)
        {
            _EquipmentNameRepository = EquipmentNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedEquipmentNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<EquipmentName> codeValues = await _EquipmentNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.EquipmentNameId
            }).ToList();
            return selectModels;
        }
    }
}
