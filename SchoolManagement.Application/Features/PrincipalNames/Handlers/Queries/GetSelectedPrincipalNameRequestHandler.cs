using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PrincipalNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PrincipalNames.Handlers.Queries
{
    public class GetSelectedPrincipalNameRequestHandler : IRequestHandler<GetSelectedPrincipalNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PrincipalName> _PrincipalNameRepository;


        public GetSelectedPrincipalNameRequestHandler(ISchoolManagementRepository<PrincipalName> PrincipalNameRepository)
        {
            _PrincipalNameRepository = PrincipalNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPrincipalNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<PrincipalName> codeValues = await _PrincipalNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.PrincipalNameId
            }).ToList();
            return selectModels;
        }
    }
}
