using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.LocalAgents.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LocalAgents.Handlers.Queries
{
    public class GetSelectedLocalAgentRequestHandler : IRequestHandler<GetSelectedLocalAgentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<LocalAgent> _LocalAgentRepository;


        public GetSelectedLocalAgentRequestHandler(ISchoolManagementRepository<LocalAgent> LocalAgentRepository)
        {
            _LocalAgentRepository = LocalAgentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedLocalAgentRequest request, CancellationToken cancellationToken)
        {
            ICollection<LocalAgent> codeValues = await _LocalAgentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.LocalAgentId
            }).ToList();
            return selectModels;
        }
    }
}
