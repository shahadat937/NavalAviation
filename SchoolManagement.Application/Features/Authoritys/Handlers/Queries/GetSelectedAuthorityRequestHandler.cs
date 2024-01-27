using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Authoritys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Authoritys.Handlers.Queries
{
    public class GetSelectedAuthorityRequestHandler : IRequestHandler<GetSelectedAuthorityRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Authority> _AuthorityRepository;


        public GetSelectedAuthorityRequestHandler(ISchoolManagementRepository<Authority> AuthorityRepository)
        {
            _AuthorityRepository = AuthorityRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAuthorityRequest request, CancellationToken cancellationToken)
        {
            ICollection<Authority> codeValues = await _AuthorityRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.AuthorityId
            }).ToList();
            return selectModels;
        }
    }
}
