using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.NameofPublications.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Queries
{
    public class GetSelectedNameofPublicationRequestHandler : IRequestHandler<GetSelectedNameofPublicationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<NameofPublication> _NameofPublicationRepository;


        public GetSelectedNameofPublicationRequestHandler(ISchoolManagementRepository<NameofPublication> NameofPublicationRepository)
        {
            _NameofPublicationRepository = NameofPublicationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNameofPublicationRequest request, CancellationToken cancellationToken)
        {
            ICollection<NameofPublication> codeValues = await _NameofPublicationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.NameofPublicationId
            }).ToList();
            return selectModels;
        }
    }
}
