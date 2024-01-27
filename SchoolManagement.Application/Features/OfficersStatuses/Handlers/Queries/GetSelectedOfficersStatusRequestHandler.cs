using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Queries
{
    public class GetSelectedOfficersStatusRequestHandler : IRequestHandler<GetSelectedOfficersStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OfficersStatus> _OfficersStatusRepository;


        public GetSelectedOfficersStatusRequestHandler(ISchoolManagementRepository<OfficersStatus> OfficersStatusRepository)
        {
            _OfficersStatusRepository = OfficersStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOfficersStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<OfficersStatus> codeValues = await _OfficersStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.OfficersStatusId
            }).ToList();
            return selectModels;
        }
    }
}
