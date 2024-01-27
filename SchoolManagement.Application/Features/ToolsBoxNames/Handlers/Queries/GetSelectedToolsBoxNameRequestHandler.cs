using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Handlers.Queries
{
    public class GetSelectedToolsBoxNameRequestHandler : IRequestHandler<GetSelectedToolsBoxNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ToolsBoxName> _ToolsBoxNameRepository;


        public GetSelectedToolsBoxNameRequestHandler(ISchoolManagementRepository<ToolsBoxName> ToolsBoxNameRepository)
        {
            _ToolsBoxNameRepository = ToolsBoxNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedToolsBoxNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<ToolsBoxName> codeValues = await _ToolsBoxNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ToolsBoxNameId
            }).ToList();
            return selectModels;
        }
    }
}
