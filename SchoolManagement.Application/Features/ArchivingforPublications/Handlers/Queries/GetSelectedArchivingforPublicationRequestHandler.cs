using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Queries
{
    public class GetSelectedArchivingforPublicationRequestHandler : IRequestHandler<GetSelectedArchivingforPublicationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ArchivingforPublication> _ArchivingforPublicationRepository;


        public GetSelectedArchivingforPublicationRequestHandler(ISchoolManagementRepository<ArchivingforPublication> ArchivingforPublicationRepository)
        {
            _ArchivingforPublicationRepository = ArchivingforPublicationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedArchivingforPublicationRequest request, CancellationToken cancellationToken)
        {
            ICollection<ArchivingforPublication> codeValues = await _ArchivingforPublicationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DocumentName,
                Value = x.ArchivingforPublicationId
            }).ToList();
            return selectModels;
        }
    }
}
