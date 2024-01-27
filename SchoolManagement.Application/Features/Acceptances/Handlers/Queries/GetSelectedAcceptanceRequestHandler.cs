using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetSelectedAcceptanceRequestHandler : IRequestHandler<GetSelectedAcceptanceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;


        public GetSelectedAcceptanceRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository)
        {
            _AcceptanceRepository = AcceptanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAcceptanceRequest request, CancellationToken cancellationToken)
        {
            ICollection<Acceptance> codeValues = await _AcceptanceRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Model,
                Value = x.AcceptanceId
            }).ToList();
            return selectModels;
        }
    }
}
