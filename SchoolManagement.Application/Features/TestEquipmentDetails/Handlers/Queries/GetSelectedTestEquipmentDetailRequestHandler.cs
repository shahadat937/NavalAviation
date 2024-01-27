using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Queries
{
    public class GetSelectedTestEquipmentDetailRequestHandler : IRequestHandler<GetSelectedTestEquipmentDetailRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TestEquipmentDetail> _TestEquipmentDetailRepository;


        public GetSelectedTestEquipmentDetailRequestHandler(ISchoolManagementRepository<TestEquipmentDetail> TestEquipmentDetailRepository)
        {
            _TestEquipmentDetailRepository = TestEquipmentDetailRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTestEquipmentDetailRequest request, CancellationToken cancellationToken)
        {
            ICollection<TestEquipmentDetail> codeValues = await _TestEquipmentDetailRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.EquipmentName,
                Value = x.TestEquipmentDetailId
            }).ToList();
            return selectModels;
        }
    }
}
