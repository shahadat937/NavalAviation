using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Queries
{
    public class GetSelectedAcStatusRequestHandler : IRequestHandler<GetSelectedAcStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AcStatus> _AcStatusRepository;


        public GetSelectedAcStatusRequestHandler(ISchoolManagementRepository<AcStatus> AcStatusRepository)
        {
            _AcStatusRepository = AcStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAcStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<AcStatus> codeValues = await _AcStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Status,
                Value = x.AcStatusId
            }).ToList();
            return selectModels;
        }
    }
}
