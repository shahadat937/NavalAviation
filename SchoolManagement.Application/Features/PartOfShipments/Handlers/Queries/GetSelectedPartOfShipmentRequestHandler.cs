using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Queries
{
    public class GetSelectedPartOfShipmentRequestHandler : IRequestHandler<GetSelectedPartOfShipmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PartOfShipment> _PartOfShipmentRepository;


        public GetSelectedPartOfShipmentRequestHandler(ISchoolManagementRepository<PartOfShipment> PartOfShipmentRepository)
        {
            _PartOfShipmentRepository = PartOfShipmentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPartOfShipmentRequest request, CancellationToken cancellationToken)
        {
            ICollection<PartOfShipment> codeValues = await _PartOfShipmentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.PartOfShipmentId
            }).ToList();
            return selectModels;
        }
    }
}
