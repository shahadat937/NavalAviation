using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Handlers.Queries
{
    public class GetSelectedProcurementStatusRequestHandler : IRequestHandler<GetSelectedProcurementStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ProcurementStatus> _ProcurementStatusRepository;


        public GetSelectedProcurementStatusRequestHandler(ISchoolManagementRepository<ProcurementStatus> ProcurementStatusRepository)
        {
            _ProcurementStatusRepository = ProcurementStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedProcurementStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<ProcurementStatus> codeValues = await _ProcurementStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ProcurementStatusId
            }).ToList();
            return selectModels;
        }
    }
}
