using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models; 

namespace SchoolManagement.Application.Features.DemandAuthorities.Handlers.Queries
{
    public class GetSelectedDemandAuthorityRequestHandler : IRequestHandler<GetSelectedDemandAuthorityRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<DemandAuthority> _DemandAuthorityRepository;


        public GetSelectedDemandAuthorityRequestHandler(ISchoolManagementRepository<DemandAuthority> DemandAuthorityRepository)
        {
            _DemandAuthorityRepository = DemandAuthorityRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDemandAuthorityRequest request, CancellationToken cancellationToken)
        {
            ICollection<DemandAuthority> codeValues = await _DemandAuthorityRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.DemandAuthorityId
            }).ToList();
            return selectModels;
        }
    }
}
