using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ToolsTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsTypes.Handlers.Queries
{
    public class GetSelectedToolsTypeRequestHandler : IRequestHandler<GetSelectedToolsTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ToolsType> _ToolsTypeRepository;


        public GetSelectedToolsTypeRequestHandler(ISchoolManagementRepository<ToolsType> ToolsTypeRepository)
        {
            _ToolsTypeRepository = ToolsTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedToolsTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ToolsType> codeValues = await _ToolsTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ToolsTypeId
            }).ToList();
            return selectModels;
        }
    }
}
