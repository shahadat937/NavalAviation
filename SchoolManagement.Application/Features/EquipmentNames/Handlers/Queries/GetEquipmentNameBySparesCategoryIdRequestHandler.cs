using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Queries
{
    public class GetEquipmentNameBySparesCategoryIdRequestHandler : IRequestHandler<GetEquipmentNameBySparesCategoryIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<EquipmentName> _EquipmentNameRepository;

          
        public GetEquipmentNameBySparesCategoryIdRequestHandler(ISchoolManagementRepository<EquipmentName> EquipmentNameRepository)
        {
            _EquipmentNameRepository = EquipmentNameRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetEquipmentNameBySparesCategoryIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<EquipmentName> EquipmentNames = await _EquipmentNameRepository.FilterAsync(x =>x.SparesCategoryId==request.SparesCategoryId);
            List<SelectedModel> selectModels = EquipmentNames.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.EquipmentNameId
            }).ToList();
            return selectModels;
        }
    }
}
